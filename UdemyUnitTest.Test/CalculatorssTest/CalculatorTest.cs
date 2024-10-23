using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyUnitTest.APP.Calculatorss;
using UdemyUnitTest.APP.Interfaces;

namespace UdemyUnitTest.Test.CalculatorssTest
{
    public class CalculatorTest
    {
        public Calculator calculator { get; }
        public Mock<ICalculatorService> myMock { get; } //Hangi interface i taklit edeceksek onu burada geçiyoruz 

        public CalculatorTest()
        {
            myMock = new Mock<ICalculatorService>();
            calculator = new Calculator(myMock.Object); // Mock'u enjekte ediyoruz
        }

        //[Fact] //Test edilebilecek metot varsa bende varım der ve parametre almadığı için bu fact metodunu yazarız 
        ////test metotları geri değer döndürmaz
        public void AddTest()
        {
            //Arrange 
            //Değişkenleri initial ettiğimiz alan 

            //int a = 5;
            //int b = 20;

            //var calculator = new Calculator();  
            ////Act
            //var total = calculator.add(a, b);

            ////Assert
            //Assert.Equal<int>(25, total);


            //Assert.Contains("Berkan", "Berkan Kara"); //Beklenen değer ve gerçek değer 

            //Assert.DoesNotContain("Berkan", "Berkan Kara");//Bu false döner çünkü aynı olmamsı gerekir




            //var names = new List<string>() { "Berkan", "Emre", "Fatih" };

            //Assert.Contains(names, x => x == "Berkan");
            ////Bu liste içerisinde berkan var mı varsa true yoksa false dönecek
            ///


            //Assert.False(5 < 2); //şart doğru olduğu için true döner 
            //Assert.True (6 < 2); //Şart yanlış olduğu içiin false döner
            //Assert.True("".GetType() == typeof(string));//Tipleri string olduğu için true



            //var regEx = "^dog";
            ////Assert.Matches(regEx, "dog fatih");//Buradaki string ifade dogla başladığından dolayı bu ifade true dönecek
            //Assert.Matches(regEx, "fatih dog"); //ifade dog ile başlamadığı için false dönecek

            //Assert.StartsWith("Bir", "Bir masal"); //Birle başladığından dolayı hata vermez 
            //Assert.EndsWith("masal", "Bir masal");//True alırız ifade masalla bitti


            //Assert.Empty(new List<string>()); //Boş olduğu için true döner
            //Assert.Empty(new List<string>(){"berkan"});//Boş olmadığı için false döner
            //Assert.NotEmpty(new List<string>() { "ahmet" }); //İçerisi dolu true 


            //Assert.InRange(5, 7, 6); //False döner 7 6 arasında 5 yok
            //Assert.NotInRange(5, 7, 6); //True döndü değer aralığında yok

            //Assert.Single(new List<string> { "a","b" }); //iki eleman var false döner
            //Assert.Single(new List<string> { "a,b,d,c" }); //true döner tek eleman var 
            //Assert.Single<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, }); //False
            //Assert.Single<int>(new List<int> { 1});  true döner,


            //Assert.IsType<int>("berkan");//içerisinde yazdığım string olduğu için true dönecek ama int girseydim false dönecekti
            //Assert.IsType<int>("berkan"); false
            //Assert.IsNotType<int>("berkan"); //içerisinde girilen değer int olmadığı için true dönecek int girsem false dönerdi

            //BU ÖNEMLİ
            //Assert.IsAssignableFrom<IEnumerable<string>>(new List<string>());//TRUE DÖNER
            //Assert.IsAssignableFrom<Object>("berkan");//String ifadeler objeden miras alır ve bu ifade true döner int de true döner 


            //string deger = null;
            //Assert.Null(deger); //True döndü
            //Assert.NotNull(deger); //deger null olduğu için false döndü


            //Assert.Equal<int>(2,2); //Bu iki değer aynı olduğu için true döner 

        }



        [Theory] //metot parametre aldığı için kullandık
        [InlineData(2, 5, 7)] //a b ve total değeri verdik
        public void Add_simpleValues_ReturnTotalValue(int a, int b, int expectedtotal)
        {
            myMock.Setup(x => x.add(a, b)).Returns(expectedtotal); //Burası çalışıyor taklit ediyoruz 

            //var calculator = new Calculator(); yukarıda geçtik buna gerek yok artık

            var actualData = calculator.add(a, b);

            Assert.Equal(expectedtotal, actualData);

            myMock.Verify(x => x.add(a, b), Times.Once); //Bu method bir kere çalışsın demek 

        }


        //[Theory] //metot parametreli
        //[InlineData(5, 6, 30)]
        //public void Multipt_SimpleValues_ReturnMultipValue(int a, int b, int expectedValue)
        //{
        //    myMock.Setup(x => x.multipt(a, b)).Returns(expectedValue);

        //    var actualData = calculator.multip(a, b);

        //    Assert.Equal(expectedValue, actualData);
        //}

        [Theory]
        [InlineData(0, 5)]
        public void Multip_ZeroValue_ReturnException(int a, int b)
        {
            myMock.Setup(x => x.multipt(a, b)).Throws(new Exception("a = 0 olamaz"));

            Exception exception = Assert.Throws<Exception>(() => calculator.multip(a, b));

            Assert.Equal("a=0 olamaz", exception.Message);
        } 
        //Equal metodu parametre içinde ki değerlerin aynı olmasını bekler


    }
}
