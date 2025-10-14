using System;
using System.Linq;
using Xunit;
using TestExam;

namespace TestDesafio
{
    public class TestDesafio2Tests
    {
        private readonly IDesafioTecnico _service;
        private readonly DesafioTecnicoImpl _mock;
        public TestDesafio2Tests()
        {
            // Replace with your actual implementation
            _service = new DesafioTecnico();
            _mock = new DesafioTecnicoImpl();
        }

        [Theory]
        [InlineData("()", true)]
        [InlineData("([])", true)]
        [InlineData("([)]", false)]
        [InlineData("(", false)]
        [InlineData("{[()]}", true)]
        public void ParentesisBalanceados_ValidatesCorrectly(string expr, bool expected)
        {
            Assert.Equal(expected, DesafioTecnico2.ParentesisBalanceados(expr));
        }

        [Fact]
        public void ColaConDosPilas_BehavesAsQueue()
        {
            var cola = new DesafioTecnico2.ColaConDosPilas<int>();
            cola.Enqueue(1);
            cola.Enqueue(2);
            cola.Enqueue(3);
            Assert.Equal(1, cola.Dequeue());
            Assert.Equal(2, cola.Peek());
            Assert.False(cola.IsEmpty);
            Assert.Equal(2, cola.Dequeue());
            Assert.Equal(3, cola.Dequeue());
            Assert.True(cola.IsEmpty);
        }

        [Fact]
        public void ColaConDosPilas_ThrowsOnEmpty()
        {
            var cola = new DesafioTecnico2.ColaConDosPilas<int>();
            Assert.Throws<InvalidOperationException>(() => cola.Dequeue());
            Assert.Throws<InvalidOperationException>(() => cola.Peek());
        }

        [Fact]
        public void ContarFrecuencia_CountsElements()
        {
            var input = new[] { 1, 2, 2, 3, 1 };
            var freq = DesafioTecnico2.ContarFrecuencia(input);
            Assert.Equal(2, freq[1]);
            Assert.Equal(2, freq[2]);
            Assert.Equal(1, freq[3]);
            var freq2 = _mock.ContarFrecuencia(input);
            Assert.Equal(2, freq2[1]);
            Assert.Equal(2, freq2[2]);
            Assert.Equal(1, freq2[3]);
        }

        [Fact]
        public void TieneDuplicados_DetectsDuplicates()
        {
            Assert.True(DesafioTecnico2.TieneDuplicados(new[] { 1, 2, 2 }));
            Assert.False(DesafioTecnico2.TieneDuplicados(new[] { 1, 2, 3 }));
            Assert.True(_mock.TieneDuplicados(new[] { 1, 2, 2 }));
            Assert.False(_mock.TieneDuplicados(new[] { 1, 2, 3 }));
        }

        [Fact]
        public void RevertirListaEnlazada_ReversesList()
        {
            var n1 = new DesafioTecnico2.Nodo<int>(1);
            var n2 = new DesafioTecnico2.Nodo<int>(2);
            var n3 = new DesafioTecnico2.Nodo<int>(3);
            n1.Siguiente = n2;
            n2.Siguiente = n3;
            var reversed = DesafioTecnico2.RevertirListaEnlazada(n1);
            Assert.Equal(3, reversed.Valor);
            Assert.Equal(2, reversed.Siguiente.Valor);
            Assert.Equal(1, reversed.Siguiente.Siguiente.Valor);
            Assert.Null(reversed.Siguiente.Siguiente.Siguiente);
        }

        [Fact]
        public void TieneCicloListaEnlazada_DetectsCycle()
        {
            var n1 = new DesafioTecnico2.Nodo<int>(1);
            var n2 = new DesafioTecnico2.Nodo<int>(2);
            var n3 = new DesafioTecnico2.Nodo<int>(3);
            n1.Siguiente = n2;
            n2.Siguiente = n3;
            n3.Siguiente = n1; // cycle
            Assert.True(DesafioTecnico2.TieneCicloListaEnlazada(n1));
        }

        [Fact]
        public void TieneCicloListaEnlazada_NoCycle()
        {
            var n1 = new DesafioTecnico2.Nodo<int>(1);
            var n2 = new DesafioTecnico2.Nodo<int>(2);
            var n3 = new DesafioTecnico2.Nodo<int>(3);
            n1.Siguiente = n2;
            n2.Siguiente = n3;
            Assert.False(DesafioTecnico2.TieneCicloListaEnlazada(n1));
        }

        [Fact]
        public void FibonacciModificado_ReturnsFilteredFibonacci()
        {
            var result = DesafioTecnico2.FibonacciModificado(3, x => x % 2 == 0);
            Assert.Equal(new List<int> { 0, 2, 8 }, result);

            var result2 = _mock.FibonacciModificado(3, x => x % 2 == 0);
            Assert.Equal(new List<int> { 0, 2, 8 }, result2);
        }

        [Fact]
        public void SumasConsecutivas_FindsCombinations()
        {
            var result = DesafioTecnico2.SumasConsecutivas(new[] { 1, 2, 3, 4 }, 5);
            Assert.Contains(new List<int> { 2, 3 }, result);
            Assert.Contains(new List<int> { 1, 2, 2 }, DesafioTecnico2.SumasConsecutivas(new[] { 1, 2, 2, 3 }, 5));

            var result2 = _mock.SumasConsecutivas(new[] { 1, 2, 3, 4 }, 5);
            Assert.Contains(new List<int> { 2, 3 }, result2);
            Assert.Contains(new List<int> { 1, 2, 2 }, _mock.SumasConsecutivas(new[] { 1, 2, 2, 3 }, 5));
        }

        [Fact]
        public void SeriePotenciasDeDos_GeneratesSeries()
        {
            var result = DesafioTecnico2.SeriePotenciasDeDos(4);
            Assert.Equal(new List<int> { 1, 2, 4, 8 }, result);
            var result2 = _mock.SeriePotenciasDeDos(4);
            Assert.Equal(new List<int> { 1, 2, 4, 8 }, result2);
        }

        [Fact]
        public void SumaArray_ThrowsOnNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => DesafioTecnico2.SumaArray(null));
            Assert.Throws<ArgumentException>(() => DesafioTecnico2.SumaArray(new int[0]));
            Assert.Throws<ArgumentNullException>(() => _mock.SumaArray(null));
            Assert.Throws<ArgumentException>(() => _mock.SumaArray(new int[0]));
        }

        [Fact]
        public void SumaArray_ReturnsSum()
        {
            Assert.Equal(6, DesafioTecnico2.SumaArray(new[] { 1, 2, 3 }));
            Assert.Equal(6, _mock.SumaArray(new[] { 1, 2, 3 }));
        }

        [Fact]
        public void LongitudString_ThrowsOnNullEmptyOrTooLong()
        {
            Assert.Throws<ArgumentNullException>(() => DesafioTecnico2.LongitudString(null, 5));
            Assert.Throws<ArgumentException>(() => DesafioTecnico2.LongitudString("", 5));
            Assert.Throws<ArgumentException>(() => DesafioTecnico2.LongitudString("abcdef", 5));

            Assert.Throws<ArgumentNullException>(() => _mock.LongitudString(null, 5));
            Assert.Throws<ArgumentException>(() => _mock.LongitudString("", 5));
            Assert.Throws<ArgumentException>(() => _mock.LongitudString("abcdef", 5));
        }

        [Fact]
        public void LongitudString_ReturnsLength()
        {
            Assert.Equal(4, DesafioTecnico2.LongitudString("test", 10));
            Assert.Equal(4, _mock.LongitudString("test", 10));
        }

        [Fact]
        public void ObtenerElementoPorIndice_ThrowsOnInvalid()
        {
            Assert.Throws<ArgumentNullException>(() => DesafioTecnico2.ObtenerElementoPorIndice(null, 0));
            Assert.Throws<ArgumentException>(() => DesafioTecnico2.ObtenerElementoPorIndice(new int[0], 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => DesafioTecnico2.ObtenerElementoPorIndice(new[] { 1, 2 }, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => DesafioTecnico2.ObtenerElementoPorIndice(new[] { 1, 2 }, 2));

            Assert.Throws<ArgumentNullException>(() => _mock.ObtenerElementoPorIndice(null, 0));
            Assert.Throws<ArgumentException>(() => _mock.ObtenerElementoPorIndice(new int[0], 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => _mock.ObtenerElementoPorIndice(new[] { 1, 2 }, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => _mock.ObtenerElementoPorIndice(new[] { 1, 2 }, 2));
        }

        [Fact]
        public void ObtenerElementoPorIndice_ReturnsElement()
        {
            Assert.Equal(2, DesafioTecnico2.ObtenerElementoPorIndice(new[] { 1, 2, 3 }, 1));
            Assert.Equal(2, _mock.ObtenerElementoPorIndice(new[] { 1, 2, 3 }, 1));
        }

        [Fact]
        public void ValidarEntradasUnicas_ThrowsOnDuplicatesOrNull()
        {
            Assert.Throws<ArgumentNullException>(() => DesafioTecnico2.ValidarEntradasUnicas<int>(null));
            Assert.Throws<ArgumentException>(() => DesafioTecnico2.ValidarEntradasUnicas(new[] { 1, 2, 2 }));
            Assert.Throws<ArgumentNullException>(() => _mock.ValidarEntradasUnicas<int>(null));
            Assert.Throws<ArgumentException>(() => _mock.ValidarEntradasUnicas(new[] { 1, 2, 2 }));
        }

        [Fact]
        public void ValidarEntradasUnicas_PassesForUnique()
        {
            DesafioTecnico2.ValidarEntradasUnicas(new[] { 1, 2, 3 });
            _mock.ValidarEntradasUnicas(new[] { 1, 2, 3 });
        }

        [Fact]
        public void NumeroMaximo_ReturnsMax()
        {
            Assert.Equal(3, DesafioTecnico2.numeroMaximo(new[] { 1, 2, 3 }));
            Assert.Equal(5, DesafioTecnico2.numeroMaximo(new List<int> { 1, 5, 2 }));
        }

        [Fact]
        public void FiltrarNombres_FiltraCorrectamente()
        {
            var nombres = new[] { "Ana", "Luis", "Alberto", "Maria" };
            var resultado = DesafioTecnico2.FiltrarNombres(nombres, n => n.StartsWith("A"));
            Assert.Equal(new[] { "Ana", "Alberto" }, resultado);

            var resultado2 = _mock.FiltrarNombres(nombres, n => n.StartsWith("A"));
            Assert.Equal(new[] { "Ana", "Alberto" }, resultado2);
        }

        [Fact]
        public void FiltrarNombres_ThrowsOnNombresNull()
        {
            Assert.Throws<ArgumentNullException>(() => DesafioTecnico2.FiltrarNombres(null, n => n.Length > 2));
            Assert.Throws<ArgumentNullException>(() => _mock.FiltrarNombres(null, n => n.Length > 2));
        }

        [Fact]
        public void FiltrarNombres_ThrowsOnCondicionNull()
        {
            var nombres = new[] { "Ana", "Luis" };
            Assert.Throws<ArgumentNullException>(() => DesafioTecnico2.FiltrarNombres(nombres, null));
            Assert.Throws<ArgumentNullException>(() => _mock.FiltrarNombres(nombres, null));
        }

        [Fact]
        public void FiltrarNombres_ThrowsOnNombreVacio()
        {
            var nombres = new[] { "Ana", "", "Luis" };
            Assert.Throws<ArgumentException>(() => DesafioTecnico2.FiltrarNombres(nombres, n => n.Length > 2));
            Assert.Throws<ArgumentException>(() => _mock.FiltrarNombres(nombres, n => n.Length > 2));
        }

        [Fact]
        public void FiltrarNombres_ThrowsOnNombreNull()
        {
            var nombres = new[] { "Ana", null, "Luis" };
            Assert.Throws<ArgumentException>(() => DesafioTecnico2.FiltrarNombres(nombres, n => n.Length > 2));
            Assert.Throws<ArgumentException>(() => _mock.FiltrarNombres(nombres, n => n.Length > 2));
        }
    }
}