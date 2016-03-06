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
            return this.GetDynamicSum(recordCount, "Cost");
        }

        internal List<int> GetRevenueSum(int recordCount)
        {
            return this.GetDynamicSum(recordCount, "Revenue");
        }

        internal List<int> GetDynamicSum(int recordCount, string columnName)
        {
            var memberList = GetMemberDataList();

            bool propExists = typeof(MemberModel).GetProperties()
                            .Where(x => x.Name == columnName)
                            .Any();

            if (!propExists)
                throw new ArgumentException();

            var data = memberList.Select((member, index) => new { member, index })
                        .GroupBy(x => x.index / recordCount, i => i.member)
                        .Select(x => x.Sum(y => (int)y.GetType().GetProperty(columnName).GetValue(y)))
                        .ToList();

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