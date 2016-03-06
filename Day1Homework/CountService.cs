using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day1Homework
{
    internal class CountService
    {
        internal List<int> GetCostSum(int recordCount)
        {
            var memberList = GetMemberDataList();

            var data = memberList.Select((member, index) => new { member, index })
                        .GroupBy(x => x.index / recordCount, i => i.member)
                        .Select(x => x.Sum(y => y.Cost)).ToList();

            return data;
        }

        internal List<int> GetRevenueSum(int recordCount)
        {
            var memberList = GetMemberDataList();

            var data = memberList.Select((member, index) => new { member, index })
                        .GroupBy(x => x.index / recordCount, i => i.member)
                        .Select(x => x.Sum(y => y.Revenue)).ToList();

            return data;
        }

        internal virtual List<MemberModel> GetMemberDataList()
        {
            var memberList = new List<MemberModel>();

            memberList.Add(new MemberModel() { Id = 1, Cost = 1, Revenue = 10, SellPrice = 100 });
            memberList.Add(new MemberModel() { Id = 2, Cost = 2, Revenue = 20, SellPrice = 200 });
            memberList.Add(new MemberModel() { Id = 3, Cost = 3, Revenue = 30, SellPrice = 300 });
            memberList.Add(new MemberModel() { Id = 4, Cost = 4, Revenue = 40, SellPrice = 400 });
            memberList.Add(new MemberModel() { Id = 5, Cost = 5, Revenue = 50, SellPrice = 500 });

            return memberList;
        }
    }
}