using Horoko.InventoryManagment.Database.Models;
using Horoko.InventoryManagment.Services.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestingProject
{
    public class UnitTest1
    {
        [Fact]
        public void MostSalesDay()
        {
            //Arrange
            List<SalesRecord> sales = new List<SalesRecord>
            {
                new SalesRecord()
                {
                    IngredientPortionId = 1,
                    DateAndTimeOfOrder = new DateTime(2022,1,1),
                    Amount = 2,
                    Price = 10
                },
                new SalesRecord()
                {
                    IngredientPortionId = 2,
                    DateAndTimeOfOrder = new DateTime(2022,1,1),
                    Amount = 3,
                    Price = 10
                },
                new SalesRecord()
                {
                    IngredientPortionId = 3,
                    DateAndTimeOfOrder = new DateTime(2022,1,2),
                    Amount = 2,
                    Price = 10
                }
            };
            WorkableService ws = new WorkableService();
            //Act
            var actual = ws.GetMostSalesMadeDate(sales);
            var expected = new DateTime(2022, 1, 1);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MostProfitableWeek()
        {
            //Arrange
            List<SalesRecord> sales = new List<SalesRecord>
            {
                new SalesRecord()
                {
                    IngredientPortionId = 1,
                    DateAndTimeOfOrder = new DateTime(2022,1,1),
                    Amount = 2,
                    Price = 10
                },
                new SalesRecord()
                {
                    IngredientPortionId = 2,
                    DateAndTimeOfOrder = new DateTime(2022,1,1),
                    Amount = 3,
                    Price = 10
                },
                new SalesRecord()
                {
                    IngredientPortionId = 3,
                    DateAndTimeOfOrder = new DateTime(2022,1,12),
                    Amount = 2,
                    Price = 10
                }
            };
            WorkableService ws = new WorkableService();
            //Act
            var actual = ws.MostProfitableWeek(sales);
            var expected = 1;
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
