using Xunit;
using TestExam;
using System.Collections.Generic;

namespace TestDesafio
{
    public class UnitTest1
    {
        private readonly IDesafioTecnico _service;
        private readonly DesafioTecnicoImpl _mock;
        public UnitTest1()
        {
            // Replace with your actual implementation
            _service = new DesafioTecnico();
            _mock = new DesafioTecnicoImpl();
        }

        [Fact]
        public void BubbleSort_SortsArray()
        {
            var result = _service.BubbleSort(new[] { 3, 1, 2 });
            Assert.Equal(new[] { 1, 2, 3 }, result);
            var result2 = _mock.BubbleSort(new[] { 3, 1, 2 });
            Assert.Equal(new[] { 1, 2, 3 }, result2);
        }

        [Fact]
        public void BusquedaBinaria_FindsElement()
        {
            var result = _service.BusquedaBinaria(new[] { 1, 2, 3, 4, 5 }, 3);
            Assert.Equal(2, result);
            var result2 = _mock.BusquedaBinaria(new[] { 1, 2, 3, 4, 5 }, 3);
            Assert.Equal(2, result2);
        }

        [Fact]
        public void ContarPalabras_CountsWords()
        {
            var result = _service.ContarPalabras("hola mundo hola");
            Assert.Equal(2, result["hola"]);
            Assert.Equal(1, result["mundo"]);
            var result2 = _mock.ContarPalabras("hola mundo hola");
            Assert.Equal(2, result2["hola"]);
            Assert.Equal(1, result2["mundo"]);
        }

        [Fact]
        public void EliminarDuplicados_RemovesDuplicates()
        {
            var result = _service.EliminarDuplicados(new[] { 1, 2, 2, 3 });
            Assert.Equal(new[] { 1, 2, 3 }, result);
            var result2 = _mock.EliminarDuplicados(new[] { 1, 2, 2, 3 });
            Assert.Equal(new[] { 1, 2, 3 }, result2);
        }

        [Fact]
        public void EncontrarParesConSuma_FindsPairs()
        {
            var result = _service.EncontrarParesConSuma(new[] { 1, 2, 3, 4 }, 5);
            Assert.Contains((1, 4), result);
            Assert.Contains((2, 3), result);
            var result2 = _mock.EncontrarParesConSuma(new[] { 1, 2, 3, 4 }, 5);
            Assert.Contains((1, 4), result2);
            Assert.Contains((2, 3), result2);
        }

        [Fact]
        public void EsPalindromoCadena_TrueForPalindrome()
        {
            Assert.True(_service.EsPalindromoCadena("ana"));
            Assert.False(_service.EsPalindromoCadena("hola"));
            Assert.True(_mock.EsPalindromoCadena("ana"));
            Assert.False(_mock.EsPalindromoCadena("hola"));
        }

        [Fact]
        public void EsPrimo_TrueForPrime()
        {
            Assert.True(_service.EsPrimo(7));
            Assert.False(_service.EsPrimo(8));
            Assert.True(_mock.EsPrimo(23));
            Assert.False(_mock.EsPrimo(24));
        }

        [Fact]
        public void FactorialIterativo_CorrectResult()
        {
            Assert.Equal(120, _service.FactorialIterativo(5));
            Assert.Equal(120, _mock.FactorialIterativo(5));
        }

        [Fact]
        public void FactorialRecursivo_CorrectResult()
        {
            Assert.Equal(120, _service.FactorialRecursivo(5));
        }

        [Fact]
        public void FibonacciIterativo_CorrectResult()
        {
            Assert.Equal(5, _service.FibonacciIterativo(5));
            Assert.Equal(5, _mock.FibonacciIterativo(5));
        }

        [Fact]
        public void FibonacciRecursivo_CorrectResult()
        {
            Assert.Equal(5, _service.FibonacciRecursivo(5));
        }

        [Fact]
        public void FormarNumeroMayor_FormsLargestNumber()
        {
            Assert.Equal(321, _service.FormarNumeroMayor(new[] { 1, 2, 3 }));
            Assert.Equal(321, _mock.FormarNumeroMayor(new[] { 1, 2, 3 }));
        }

        [Fact]
        public void KEsimoMayor_ReturnsKEsimoLargest()
        {
            Assert.Equal(2, _service.KEsimoMayor(new[] { 1, 2, 3 }, 2));
            Assert.Equal(2, _mock.KEsimoMayor(new[] { 1, 2, 3 }, 2));
        }

        [Fact]
        public void KEsimoMayor_ThrowsExceptionForInvalidK()
        {
            var array = new[] { 1, 2, 3 };

            Assert.Throws<ArgumentOutOfRangeException>(() => _service.KEsimoMayor(array, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => _service.KEsimoMayor(array, 4));

            Assert.Throws<ArgumentOutOfRangeException>(() => _mock.KEsimoMayor(array, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => _mock.KEsimoMayor(array, 4));
        }

        [Fact]
        public void KEsimoMenor_ReturnsKEsimoSmallest()
        {
            Assert.Equal(2, _service.KEsimoMenor(new[] { 1, 2, 3 }, 2));
        }

        [Fact]
        public void MoverCerosAlFinal_MovesZeros()
        {
            var result = _service.MoverCerosAlFinal(new[] { 0, 1, 0, 3 });
            Assert.Equal(new[] { 1, 3, 0, 0 }, result);
            var result2 = _mock.MoverCerosAlFinal(new[] { 0, 1, 0, 3 });
            Assert.Equal(new[] { 1, 3, 0, 0 }, result2);
        }

        [Fact]
        public void RevertirArray_ReversesArray()
        {
            var result = _service.RevertirArray(new[] { 1, 2, 3 });
            Assert.Equal(new[] { 3, 2, 1 }, result);
            var result2 = _mock.RevertirArray(new[] { 1, 2, 3 });
            Assert.Equal(new[] { 3, 2, 1 }, result2);
        }

        [Fact]
        public void SonAnagramas_TrueForAnagrams()
        {
            Assert.True(_service.SonAnagramas("roma", "amor"));
            Assert.False(_service.SonAnagramas("hola", "mundo"));
        }

        [Fact]
        public void SonAnagramasPorOrden_TrueForAnagrams()
        {
            Assert.True(_service.SonAnagramasPorOrden("roma", "amor"));
            Assert.False(_service.SonAnagramasPorOrden("hola", "mundo"));
        }
    }
}