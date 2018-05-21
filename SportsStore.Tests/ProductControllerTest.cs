using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using Xunit;

namespace SportsStore.Tests
{
    public class ProductControllerTest
    {
        [Fact]
        public void Can_Paginate()
        {
            //Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"},
                new Product {ProductId = 4, Name = "P4"},
                new Product {ProductId = 5, Name = "P5"}
            }).AsQueryable<Product>());

            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;

            //Act
            ProductsListViewModel result = controller.List(null,2).ViewData.Model as ProductsListViewModel;

            //Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4",prodArray[0].Name);
            Assert.Equal("P5",prodArray[1].Name);
        }

        [Fact]
        public void Cand_Send_Pagination_ViewModel()
        {
            //Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"},
                new Product {ProductId = 4, Name = "P4"},
                new Product {ProductId = 5, Name = "P5"}
            }).AsQueryable<Product>());

            ProductController controller = new ProductController(mock.Object) {pageSize = 3};


            //Act

            ProductsListViewModel result = controller.List(null,2).ViewData.Model as ProductsListViewModel;

            //Assert
            PagingInfo pagingInfo = result.PagingInfo;

            Assert.Equal(2,pagingInfo.CurrentPage);
            Assert.Equal(3,pagingInfo.ItemsPerPage);
            Assert.Equal(5,pagingInfo.TotalItems);
            Assert.Equal(2,pagingInfo.TotalPages);
        }
    }
}
