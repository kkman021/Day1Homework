using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day1Homework.Tests
{
    [TestClass()]
    public class CountServiceTests
    {
        private List<MemberModel> testMemberList;

        public CountServiceTests()
        {
            testMemberList = new List<MemberModel>();

            testMemberList.Add(new MemberModel() { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21 });
            testMemberList.Add(new MemberModel() { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22 });
            testMemberList.Add(new MemberModel() { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23 });
            testMemberList.Add(new MemberModel() { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24 });
            testMemberList.Add(new MemberModel() { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25 });
            testMemberList.Add(new MemberModel() { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26 });
            testMemberList.Add(new MemberModel() { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27 });
            testMemberList.Add(new MemberModel() { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28 });
            testMemberList.Add(new MemberModel() { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29 });
            testMemberList.Add(new MemberModel() { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30 });
            testMemberList.Add(new MemberModel() { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31 });
        }

        [TestMethod()]
        public void GetCostSumTest_recordCount_3_should_listcount_4_should_listcontent_6_15_24_21()
        {
            //arrange
            var recordCount = 3;
            var columnName = "Cost";
            var expected = new List<int>() { 6, 15, 24, 21 };

            //act
            var act = new StubCountService();
            act.SetMemberList(testMemberList);
            var acture = act.GetDynamicSum(recordCount, columnName);

            //accsert
            acture.Should().NotBeEmpty()
                 .And.HaveCount(expected.Count)
                 .And.ContainInOrder(expected)
                 .And.ContainItemsAssignableTo<int>();
        }

        [TestMethod()]
        public void GetRevenueSumTest_recordCount_4_should_listcount_3_should_listcontent_50_66_60()
        {
            //arrange
            var recordCount = 4;
            var columnName = "Revenue";

            var expected = new List<int>() { 50, 66, 60 };

            //act
            var act = new StubCountService();
            act.SetMemberList(testMemberList);
            var acture = act.GetDynamicSum(recordCount, columnName);

            //accsert
            acture.Should().NotBeEmpty()
                 .And.HaveCount(expected.Count)
                 .And.ContainInOrder(expected)
                 .And.ContainItemsAssignableTo<int>();
        }
    }

    internal class StubCountService : CountService
    {
        public List<MemberModel> _MemberList { get; private set; }

        internal void SetMemberList(List<MemberModel> memberList)
        {
            this._MemberList = memberList;
        }

        internal override List<MemberModel> GetMemberDataList()
        {
            return this._MemberList;
        }
    }
}