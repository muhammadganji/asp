using ConsoleApp1.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace ConsoleApp1.Test
{
    
    public class MathHelperTest
    {
        /// <summary>
        /// نمایش نتیجه تست ها
        /// </summary>
        private readonly ITestOutputHelper _putputHelper;
        public MathHelperTest(ITestOutputHelper putputHelper)
        {
            _putputHelper = putputHelper;
        }

        //[Fact]
        [Theory]
        [InlineData(5,10,15)]
        [InlineData(-10,15,5)]
        [Trait("service","InlineData")]
        public void JamTest(int x, int y, int Expected)
        {
            MathHelper mathHelper = new MathHelper();
            //int x = 4, y = 5;
            var result = mathHelper.Jam(x, y);
            Assert.Equal(Expected, result);
            Assert.IsType<int>(result);

        }


        [Theory]
        [MemberData(nameof(DataForTest.GetDataJam),MemberType = typeof(DataForTest))]
        [Trait("Service","MemberData")]
        public void jam_MemberData_Test(int x, int y, int Expected)
        {
            MathHelper mathHelper = new MathHelper();
            //int x = 4, y = 5;
            var result = mathHelper.Jam(x, y);
            Assert.Equal(Expected, result);
            Assert.IsType<int>(result);
        }

        [Theory]
        [ClassData(typeof(MemberData))]
        [Trait("Service", "classData")]
        public void jam_ClassData_Test(int x, int y, int Expected)
        {
            MathHelper mathHelper = new MathHelper();
            //int x = 4, y = 5;
            var result = mathHelper.Jam(x, y);
            _putputHelper.WriteLine($" DETAILS: {x} + {y} = {result}");
            Assert.Equal(Expected, result);
            Assert.IsType<int>(result);
        }



        [Theory(Skip ="فعلا نیاز به این تست نداریم")]
        [InlineData(100,20,5)]
        public void DivisionTest(int x,int y, float Expected)
        {
            MathHelper mathHelper = new MathHelper();
            var result = mathHelper.Division(x, y);
            Assert.Equal(Expected, result);
            Assert.IsType<float>(result);
        }
        
    }
}
