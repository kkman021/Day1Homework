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

            testMemberList.Add(new MemberModel() { Id = 1, Cost = 1, Revenue = 10, SellPrice = 100 });
            testMemberList.Add(new MemberModel() { Id = 2, Cost = 2, Revenue = 20, SellPrice = 200 });
            testMemberList.Add(new MemberModel() { Id = 3, Cost = 3, Revenue = 30, SellPrice = 300 });
            testMemberList.Add(new MemberModel() { Id = 4, Cost = 4, Revenue = 40, SellPrice = 400 });
            testMemberList.Add(new MemberModel() { Id = 5, Cost = 5, Revenue = 50, SellPrice = 500 });
        }

        [TestMethod()]
        public void GetCostSumTest_recordCount_3_should_listcount_2_should_listcontent_6_9()
        {
            //arrange
            var recordCount = 3;
            var expected = new List<int>() { 6, 9 };

            //act
            var act = new StubCountService();
            act.SetMemberList(testMemberList);
            var acture = act.GetCostSum(recordCount);

            //accsert
            expected.Should().ContainInOrder(expected);
        }

        [TestMethod()]
        public void GetCostSumTest_recordCount_4_should_listcount_2_should_listcontent_10_5()
        {
            //arrange
            var recordCount = 4;
            var expected = new List<int>() { 10, 5 };

            //act
            var act = new StubCountService();
            act.SetMemberList(testMemberList);
            var acture = act.GetCostSum(recordCount);

            //accsert
            expected.Should().ContainInOrder(expected);
        }

        [TestMethod()]
        public void GetRevenueSumTest_recordCount_2_should_listcount_3_should_listcontent_30_70_50()
        {
            //arrange
            var recordCount = 2;
            var expected = new List<int>() { 30, 70, 50 };

            //act
            var act = new StubCountService();
            act.SetMemberList(testMemberList);
            var acture = act.GetRevenueSum(recordCount);

            //accsert
            expected.Should().ContainInOrder(expected);
        }

        [TestMethod()]
        public void GetRevenueSumTest_recordCount_4_should_listcount_2_should_listcontent_100_50()
        {
            //arrange
            var recordCount = 2;
            var expected = new List<int>() { 100, 50 };

            //act
            var act = new StubCountService();
            act.SetMemberList(testMemberList);
            var acture = act.GetRevenueSum(recordCount);

            //accsert
            expected.Should().ContainInOrder(expected);
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