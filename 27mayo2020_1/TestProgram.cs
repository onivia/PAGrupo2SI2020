using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace _27mayo2020_1
{
    //dotnet test -l "console;verbosity=detailed"
    public class TestProgram
    {
        private readonly ITestOutputHelper _output;

        public TestProgram(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(Skip="NA")]
        //[Fact(Timeout=5000)]
        public async Task tiempoTest() {
            //Caso Prueba para validar si la ejecucion del metodo toma menos de 5Segs          
            await Task.Delay(2000);
        }

        [Fact(Skip="NA")]
        //[Fact]
        public void dividir1Test() {
            //Caso Prueba para validar que el metodo 'dividir' efectivamente levanta la excepcion 'DivideByZeroException' si se pasa '0' al divisor
            Assert.Throws<DivideByZeroException>(() => Program.dividir(10,0));
        }

        [Fact(Skip="NA")]
        //[Fact]
        public void dividir2Test() {
            //Caso Prueba para validar que el metodo 'dividir' no levanta excepcion cuando al divisor se le pasa un valor != '0'
            Action a1 = () => Program.dividir(100,20);
            Exception ex = Record.Exception(a1);
            Assert.Null(ex);
        }

        //[Fact(Skip="NA")]
        [Fact]
        public void sumarTest() {
            //Caso Prueba para validar que el valor esperado es igual al obtenido como resultado de llamar el metodo
            int resultadoEsperado = 0;
            int resultadoObtenido = 0;

            _output.WriteLine($"Corriendo caso Prueba: sumarTest...");
            resultadoObtenido = Program.sumar(20,30);
            resultadoEsperado = 50;
            Assert.Equal(resultadoEsperado,resultadoObtenido);
        }

        [Theory(Skip="NA")]
        //[Theory()]
        [InlineData(1, "$")]
        [InlineData(2, "$")]
        public void posibleDatoTest(int id, string simbolo)
        {
            //Para validar que cada iteracion tiene un especifico valor, en este caso en la variable 'simbolo' tenga como valor el simbolo '$'
            Assert.Equal("$",simbolo);
        }
    }
}
