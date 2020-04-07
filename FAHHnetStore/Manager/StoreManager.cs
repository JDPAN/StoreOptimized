using FAHHnetStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAHHnetStore.Manager
{
    public class StoreManager
    {

        /// <summary>
        /// 发料运算匹配函数
        /// </summary>
        /// <param name="olist">订单列表</param>
        /// <param name="slist">库存列表</param>
        /// <param name="mlist">最小包装列表</param>
        /// <returns></returns>
        public List<SendAllocModel> StoreAiFunc(List<wois> olist, List<pt_onhand> slist, List<Pn_Unit> mlist)
        {

            List<SendAllocModel> relist = new List<SendAllocModel>();
            foreach (var order in olist)
            {
                SendAllocModel allocModel = new SendAllocModel();
                allocModel.wo = order.wo;
                allocModel.wi = order.wi;
                allocModel.pn = order.pn;
                allocModel.pndes = order.pndes;
                //1.物料需求是否发料完成
                allocModel.qty = (order.qty <= order.isu) ? 0 : (order.qty - order.isu);//当前需求数量=初步需求数量qty-已发数量isu
                if (allocModel.qty > 0)
                {
                    //2.库存匹配 （料号匹配&&数量大于0的仓库）
                    var MeetList = slist.Where(it => it.pn == allocModel.pn && it.onhand > 0).ToList();
                    if (MeetList != null && MeetList.Count > 0)
                    {
                        decimal minqty = mlist.Where(it => it.pn == allocModel.pn).Select(x => x.minUnit).FirstOrDefault();  //获取该料号最小包装数量
                        //3.取料优先级SW->MG->PT
                        var SwMeetDto = MeetList.Where(it => it.whs == "SW").FirstOrDefault();
                        var MgMeetDto = MeetList.Where(it => it.whs == "MG").FirstOrDefault();
                        var PtMeetDto = MeetList.Where(it => it.whs == "PT").FirstOrDefault();
                        if (SwMeetDto != null)
                        {
                            //4.判断SW仓库物料数量是否满足工单需求
                            if (allocModel.qty < SwMeetDto.onhand)//SW库存大于需求
                            {
                                //5.是否有最小包装数量
                                if (minqty > 0)
                                {
                                    decimal SwNeedMinPackCount = Math.Ceiling(allocModel.qty / minqty);//需求最小包装个数 Ceiling只要有小数都加1                                                                                                  
                                    decimal bulkqty = SwMeetDto.onhand % minqty;
                                    //6.是否有散料    
                                    if (bulkqty > 0)
                                    {
                                        //7.散料是否满足需求
                                        if (allocModel.qty <= bulkqty)//满足
                                        {
                                            allocModel.swisu = bulkqty;
                                            allocModel.sw_onhand = SwMeetDto.onhand;
                                            SwMeetDto.onhand = SwMeetDto.onhand - bulkqty;//散料满足，发料数量等于散料数量，库存扣除散料数量
                                            allocModel.totalisu = allocModel.swisu;
                                        }
                                        else
                                        {
                                            var mixedCount = (SwNeedMinPackCount - 1) * minqty + bulkqty;
                                            //8.散料+最小包装组合是否满足需求
                                            if (mixedCount >= allocModel.qty)
                                            {
                                                allocModel.swisu = mixedCount;
                                                allocModel.sw_onhand = SwMeetDto.onhand;
                                                SwMeetDto.onhand = SwMeetDto.onhand - allocModel.swisu;
                                                allocModel.totalisu = allocModel.swisu;
                                            }
                                            else
                                            {
                                                //散+最小包装组合不满足需求，则发放最小包装
                                                allocModel.swisu = SwNeedMinPackCount * minqty;
                                                allocModel.totalisu = allocModel.swisu;
                                                allocModel.sw_onhand = SwMeetDto.onhand;
                                                SwMeetDto.onhand = SwMeetDto.onhand - allocModel.swisu;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //SW库无散料 则发放需要的最小包装个数
                                        allocModel.swisu = SwNeedMinPackCount * minqty;
                                        allocModel.totalisu = allocModel.swisu;
                                        allocModel.sw_onhand = SwMeetDto.onhand;
                                        SwMeetDto.onhand = SwMeetDto.onhand - allocModel.swisu;
                                    }
                                }
                                else
                                {
                                    //SW库该料号无最小包装数量 
                                    allocModel.swisu = allocModel.qty;
                                    allocModel.totalisu = allocModel.swisu;
                                    allocModel.sw_onhand = SwMeetDto.onhand;
                                    SwMeetDto.onhand = SwMeetDto.onhand - allocModel.swisu;
                                }
                            }
                            else
                            {
                                //SW仓库该物料量<=需求数量
                                allocModel.sw_onhand = SwMeetDto.onhand;
                                allocModel.swisu = SwMeetDto.onhand;
                                SwMeetDto.onhand = 0;
                                allocModel.totalisu = allocModel.swisu;
                                decimal needQty = allocModel.qty - allocModel.totalisu;
                                if (needQty > 0)
                                {
                                    //9.SW仓未满足工单需求量，存在剩余需求查找MG仓
                                    if (MgMeetDto != null)
                                    {
                                        //10.判断MG仓是否满足剩余需求
                                        if (needQty < MgMeetDto.onhand)//mg库存大于剩余需求
                                        {
                                            //11.是否有最小包装数量
                                            if (minqty > 0)
                                            {
                                                decimal MgNeedMinPackCount = Math.Ceiling(needQty / minqty);
                                                decimal bulkqty = MgMeetDto.onhand % minqty;
                                                //12.是否有散料    
                                                if (bulkqty > 0)
                                                {
                                                    //13.散料是否满足需求
                                                    if (needQty <= bulkqty)//满足
                                                    {
                                                        allocModel.mg_onhand = MgMeetDto.onhand;
                                                        allocModel.mgisu = bulkqty;
                                                        MgMeetDto.onhand -= bulkqty;//散料满足，发料数量等于散料数量，库存扣除散料数量
                                                        allocModel.totalisu += allocModel.mgisu;
                                                    }
                                                    else
                                                    {
                                                        var mixedCount = (MgNeedMinPackCount - 1) * minqty + bulkqty;
                                                        //14.散料+最小包装组合是否满足需求
                                                        if (mixedCount >= needQty)
                                                        {
                                                            allocModel.mg_onhand = MgMeetDto.onhand;
                                                            allocModel.mgisu = mixedCount;
                                                            MgMeetDto.onhand -= allocModel.mgisu;
                                                            allocModel.totalisu += allocModel.mgisu;
                                                        }
                                                        else
                                                        {
                                                            //散+最小包装组合不满足需求，则发放最小包装
                                                            allocModel.mg_onhand = MgMeetDto.onhand;
                                                            allocModel.mgisu = MgNeedMinPackCount * minqty;
                                                            allocModel.totalisu += allocModel.mgisu;
                                                            MgMeetDto.onhand -= allocModel.mgisu;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //mg库无散料 则发放需要的最小包装个数
                                                    allocModel.mg_onhand = MgMeetDto.onhand;
                                                    allocModel.mgisu = MgNeedMinPackCount * minqty;
                                                    allocModel.totalisu += allocModel.mgisu;
                                                    MgMeetDto.onhand -= allocModel.mgisu;
                                                }
                                            }
                                            else
                                            {
                                                //MG库该料号无最小包装数量 
                                                allocModel.mg_onhand = MgMeetDto.onhand;
                                                allocModel.mgisu = needQty;
                                                allocModel.totalisu += allocModel.mgisu;
                                                MgMeetDto.onhand -= allocModel.mgisu;
                                            }
                                        }
                                        else
                                        {
                                            //MG仓库该物料量<=剩余需求
                                            allocModel.mg_onhand = MgMeetDto.onhand;
                                            allocModel.mgisu = MgMeetDto.onhand;
                                            MgMeetDto.onhand = 0;
                                            allocModel.totalisu += allocModel.mgisu;
                                            needQty = allocModel.qty - allocModel.totalisu;
                                            if (needQty > 0)
                                            {
                                                //15.MG仓未满足工单需求量，存在剩余需求查找PT仓
                                                if (PtMeetDto != null)
                                                {
                                                    //16.判断PT仓是否满足剩余需求
                                                    if (needQty < PtMeetDto.onhand)//pt库存大于剩余需求
                                                    {
                                                        //17.是否有最小包装数量
                                                        if (minqty > 0)
                                                        {
                                                            decimal PtNeedMinPackCount = Math.Ceiling(needQty / minqty);
                                                            decimal bulkqty = PtMeetDto.onhand % minqty;
                                                            //18.是否有散料    
                                                            if (bulkqty > 0)
                                                            {
                                                                //19.散料是否满足需求
                                                                if (needQty <= bulkqty)//满足
                                                                {
                                                                    allocModel.pt_onhand = PtMeetDto.onhand;
                                                                    allocModel.ptisu = bulkqty;
                                                                    PtMeetDto.onhand -= bulkqty;//散料满足，发料数量等于散料数量，库存扣除散料数量
                                                                    allocModel.totalisu += allocModel.ptisu;
                                                                }
                                                                else
                                                                {
                                                                    var mixedCount = (PtNeedMinPackCount - 1) * minqty + bulkqty;
                                                                    //20.散料+最小包装组合是否满足需求
                                                                    if (mixedCount >= needQty)
                                                                    {
                                                                        allocModel.pt_onhand = PtMeetDto.onhand;
                                                                        allocModel.ptisu = mixedCount;
                                                                        PtMeetDto.onhand -= allocModel.ptisu;
                                                                        allocModel.totalisu += allocModel.ptisu;
                                                                    }
                                                                    else
                                                                    {
                                                                        //散+最小包装组合不满足需求，则发放最小包装
                                                                        allocModel.pt_onhand = PtMeetDto.onhand;
                                                                        allocModel.ptisu = PtNeedMinPackCount * minqty;
                                                                        allocModel.totalisu += allocModel.ptisu;
                                                                        PtMeetDto.onhand -= allocModel.ptisu;
                                                                    }

                                                                }
                                                            }
                                                            else
                                                            {
                                                                //pt库无散料 则发放需要的最小包装个数
                                                                allocModel.pt_onhand = PtMeetDto.onhand;
                                                                allocModel.ptisu = PtNeedMinPackCount * minqty;
                                                                allocModel.totalisu += allocModel.ptisu;
                                                                PtMeetDto.onhand -= allocModel.ptisu;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            //MG库该料号无最小包装数量 
                                                            allocModel.pt_onhand = PtMeetDto.onhand;
                                                            allocModel.ptisu = needQty;
                                                            allocModel.totalisu += allocModel.ptisu;
                                                            PtMeetDto.onhand -= allocModel.ptisu;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        allocModel.pt_onhand = PtMeetDto.onhand;
                                                        allocModel.ptisu = PtMeetDto.onhand;
                                                        PtMeetDto.onhand = 0;
                                                        allocModel.totalisu += allocModel.ptisu;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (MgMeetDto != null)
                        {
                            //判断MG仓库
                            decimal needQty = allocModel.qty - allocModel.totalisu;
                            if (needQty > 0)
                            {
                                //10.判断MG仓是否满足剩余需求
                                if (needQty < MgMeetDto.onhand)//mg库存大于剩余需求
                                {
                                    //11.是否有最小包装数量
                                    if (minqty > 0)
                                    {
                                        decimal MgNeedMinPackCount = Math.Ceiling(needQty / minqty);
                                        decimal bulkqty = MgMeetDto.onhand % minqty;
                                        //12.是否有散料    
                                        if (bulkqty > 0)
                                        {
                                            //13.散料是否满足需求
                                            if (needQty <= bulkqty)//满足
                                            {
                                                allocModel.mg_onhand = MgMeetDto.onhand;
                                                allocModel.mgisu = bulkqty;
                                                MgMeetDto.onhand -= bulkqty;//散料满足，发料数量等于散料数量，库存扣除散料数量
                                                allocModel.totalisu += allocModel.mgisu;
                                            }
                                            else
                                            {
                                                var mixedCount = (MgNeedMinPackCount - 1) * minqty + bulkqty;
                                                //14.散料+最小包装组合是否满足需求
                                                if (mixedCount >= needQty)
                                                {
                                                    allocModel.mg_onhand = MgMeetDto.onhand;
                                                    allocModel.mgisu = mixedCount;
                                                    MgMeetDto.onhand -= allocModel.mgisu;
                                                    allocModel.totalisu += allocModel.mgisu;
                                                }
                                                else
                                                {
                                                    //散+最小包装组合不满足需求，则发放最小包装
                                                    allocModel.mg_onhand = MgMeetDto.onhand;
                                                    allocModel.mgisu = MgNeedMinPackCount * minqty;
                                                    allocModel.totalisu += allocModel.mgisu;
                                                    MgMeetDto.onhand -= allocModel.mgisu;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            //mg库无散料 则发放需要的最小包装个数
                                            allocModel.mg_onhand = MgMeetDto.onhand;
                                            allocModel.mgisu = MgNeedMinPackCount * minqty;
                                            allocModel.totalisu += allocModel.mgisu;
                                            MgMeetDto.onhand -= allocModel.mgisu;
                                        }
                                    }
                                    else
                                    {
                                        //MG库该料号无最小包装数量 
                                        allocModel.mg_onhand = MgMeetDto.onhand;
                                        allocModel.mgisu = needQty;
                                        allocModel.totalisu += allocModel.mgisu;
                                        MgMeetDto.onhand -= allocModel.mgisu;
                                    }
                                }
                                else
                                {
                                    //MG仓库该物料量<=剩余需求
                                    allocModel.mg_onhand = MgMeetDto.onhand;
                                    allocModel.mgisu = MgMeetDto.onhand;
                                    MgMeetDto.onhand = 0;
                                    allocModel.totalisu += allocModel.mgisu;
                                    needQty = allocModel.qty - allocModel.totalisu;
                                    if (needQty > 0)
                                    {
                                        //15.MG仓未满足工单需求量，存在剩余需求查找PT仓
                                        if (PtMeetDto != null)
                                        {
                                            //16.判断PT仓是否满足剩余需求
                                            if (needQty < PtMeetDto.onhand)//pt库存大于剩余需求
                                            {
                                                //17.是否有最小包装数量
                                                if (minqty > 0)
                                                {
                                                    decimal PtNeedMinPackCount = Math.Ceiling(needQty / minqty);
                                                    decimal bulkqty = PtMeetDto.onhand % minqty;
                                                    //18.是否有散料    
                                                    if (bulkqty > 0)
                                                    {
                                                        //19.散料是否满足需求
                                                        if (needQty <= bulkqty)//满足
                                                        {
                                                            allocModel.pt_onhand = PtMeetDto.onhand;
                                                            allocModel.ptisu = bulkqty;
                                                            PtMeetDto.onhand -= bulkqty;//散料满足，发料数量等于散料数量，库存扣除散料数量
                                                            allocModel.totalisu += allocModel.ptisu;
                                                        }
                                                        else
                                                        {
                                                            var mixedCount = (PtNeedMinPackCount - 1) * minqty + bulkqty;
                                                            //20.散料+最小包装组合是否满足需求
                                                            if (mixedCount >= needQty)
                                                            {
                                                                allocModel.pt_onhand = PtMeetDto.onhand;
                                                                allocModel.ptisu = mixedCount;
                                                                PtMeetDto.onhand -= allocModel.ptisu;
                                                                allocModel.totalisu += allocModel.ptisu;
                                                            }
                                                            else
                                                            {
                                                                //散+最小包装组合不满足需求，则发放最小包装
                                                                allocModel.pt_onhand = PtMeetDto.onhand;
                                                                allocModel.ptisu = PtNeedMinPackCount * minqty;
                                                                allocModel.totalisu += allocModel.ptisu;
                                                                PtMeetDto.onhand -= allocModel.ptisu;
                                                            }

                                                        }
                                                    }
                                                    else
                                                    {
                                                        //pt库无散料 则发放需要的最小包装个数
                                                        allocModel.pt_onhand = PtMeetDto.onhand;
                                                        allocModel.ptisu = PtNeedMinPackCount * minqty;
                                                        allocModel.totalisu += allocModel.ptisu;
                                                        PtMeetDto.onhand -= allocModel.ptisu;
                                                    }
                                                }
                                                else
                                                {
                                                    //MG库该料号无最小包装数量 
                                                    allocModel.pt_onhand = PtMeetDto.onhand;
                                                    allocModel.ptisu = needQty;
                                                    allocModel.totalisu += allocModel.ptisu;
                                                    PtMeetDto.onhand -= allocModel.ptisu;
                                                }
                                            }
                                            else
                                            {
                                                allocModel.pt_onhand = PtMeetDto.onhand;
                                                allocModel.ptisu = PtMeetDto.onhand;
                                                PtMeetDto.onhand = 0;
                                                allocModel.totalisu += allocModel.ptisu;
                                            }
                                        }
                                    }
                                }

                            }
                        }
                        else if (PtMeetDto != null)
                        {
                            decimal needQty = allocModel.qty - allocModel.totalisu;
                            if (needQty > 0)
                            {
                                //16.判断PT仓是否满足剩余需求
                                if (needQty < PtMeetDto.onhand)//pt库存大于剩余需求
                                {
                                    //17.是否有最小包装数量
                                    if (minqty > 0)
                                    {
                                        decimal PtNeedMinPackCount = Math.Ceiling(needQty / minqty);
                                        decimal bulkqty = PtMeetDto.onhand % minqty;
                                        //18.是否有散料    
                                        if (bulkqty > 0)
                                        {
                                            //19.散料是否满足需求
                                            if (needQty <= bulkqty)//满足
                                            {
                                                allocModel.pt_onhand = PtMeetDto.onhand;
                                                allocModel.ptisu = bulkqty;
                                                PtMeetDto.onhand -= bulkqty;//散料满足，发料数量等于散料数量，库存扣除散料数量
                                                allocModel.totalisu += allocModel.ptisu;
                                            }
                                            else
                                            {
                                                var mixedCount = (PtNeedMinPackCount - 1) * minqty + bulkqty;
                                                //20.散料+最小包装组合是否满足需求
                                                if (mixedCount >= needQty)
                                                {
                                                    allocModel.pt_onhand = PtMeetDto.onhand;
                                                    allocModel.ptisu = mixedCount;
                                                    PtMeetDto.onhand -= allocModel.ptisu;
                                                    allocModel.totalisu += allocModel.ptisu;
                                                }
                                                else
                                                {
                                                    //散+最小包装组合不满足需求，则发放最小包装
                                                    allocModel.pt_onhand = PtMeetDto.onhand;
                                                    allocModel.ptisu = PtNeedMinPackCount * minqty;
                                                    allocModel.totalisu += allocModel.ptisu;
                                                    PtMeetDto.onhand -= allocModel.ptisu;
                                                }

                                            }
                                        }
                                        else
                                        {
                                            //pt库无散料 则发放需要的最小包装个数
                                            allocModel.pt_onhand = PtMeetDto.onhand;
                                            allocModel.ptisu = PtNeedMinPackCount * minqty;
                                            allocModel.totalisu += allocModel.ptisu;
                                            PtMeetDto.onhand -= allocModel.ptisu;
                                        }
                                    }
                                    else
                                    {
                                        //PT库该料号无最小包装数量 
                                        allocModel.pt_onhand = PtMeetDto.onhand;
                                        allocModel.ptisu = needQty;
                                        allocModel.totalisu += allocModel.ptisu;
                                        PtMeetDto.onhand -= allocModel.ptisu;
                                    }
                                }
                                else
                                {
                                    allocModel.pt_onhand = PtMeetDto.onhand;
                                    allocModel.ptisu = PtMeetDto.onhand;
                                    PtMeetDto.onhand = 0;
                                    allocModel.totalisu += allocModel.ptisu;
                                }

                            }
                        }
                    }
                    //该料号三个库存都为空
                    relist.Add(allocModel);
                }
                //无需发料
            }
            return relist;
        }

        /// <summary>
        /// 发料汇总函数
        /// </summary>
        public List<StoreSum> StoreSumFunc(List<SendAllocModel> alloclist)
        {
            List<StoreSum> relist = new List<StoreSum>();
            if (alloclist.Count > 0)
            {
                relist = alloclist.GroupBy(g => g.pn).Select(s => new StoreSum()
                {
                    pn = s.Key,
                    pndes = s.FirstOrDefault().pndes,
                    qty = s.Sum(q => q.qty),
                    sw_onhand = s.Max(m => m.sw_onhand),
                    swisu = s.Sum(i => i.swisu),
                    mg_onhand = s.Max(m => m.mg_onhand),
                    mgisu = s.Sum(i => i.mgisu),
                    pt_onhand = s.Max(m => m.pt_onhand),
                    ptisu = s.Sum(i => i.ptisu),
                    totalisu = s.Sum(i => i.totalisu)
                }).ToList();
            }
            return relist;
        }
    }
}
