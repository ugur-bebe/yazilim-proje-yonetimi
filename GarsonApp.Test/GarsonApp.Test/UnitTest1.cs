using GarsonApp.Business.Concrete;
using GarsonApp.Services.Catalog.Abstract;
using GarsonApp.Services.Catalog.Concrete;
using GarsonApp.Services.Catalog.Core;
using GarsonApp.Services.Catalog.DAL;
using System;
using System.Reflection;
using VTYS_PROJE.Business.Concrete;
using Xunit;
using Xunit.Abstractions;

namespace GarsonApp.Test
{
    public class UnitTest1 : Xunit.Sdk.BeforeAfterTestAttribute
    {
        private readonly ITestOutputHelper output;
        ICategoryService _categoryService;
        public UnitTest1(ITestOutputHelper output)
        {
            output.WriteLine("Class öncesi");
         
            ICategoryRepository categoryRepository = new CategoryRepository();
            /*ISubCategoryDal categoryDal = new SubCategoryDal(categoryRepository);
            _categoryService = new CategoryService(categoryDal);
            this.output = output;*/
        }

        [Fact]
        public void Test1()
        {
            int id = 1;
            Assert.Equal(_categoryService.GetById(id).Data.Name,
                         "Kategori " + id);
        }
        [Fact]
        public void Test2()
        {
            int id = 1;
            Assert.Equal(_categoryService.GetById(id).Data.Name,
                         "Kategori " + 2);
        }

        public override void Before(MethodInfo methodUnderTest)
        {
            output.WriteLine("Öncesi");
        }

        public override void After(MethodInfo methodUnderTest)
        {
            output.WriteLine("Sonrasý");
        }

        public void Dispose()
        {
            output.WriteLine("Class sonrasý");
        }
    }
}
