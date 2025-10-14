using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExam
{
    public class DesafioTecnico2
    {
        // Método para validar paréntesis balanceados usando pila
        public static bool ParentesisBalanceados(string expresion)
        {
            char[] pila = new char[expresion.Length];
            int tope = -1;

            for (int i = 0; i < expresion.Length; i++)
            {
                char c = expresion[i];
                if (c == '(' || c == '[' || c == '{')
                {
                    pila[++tope] = c;
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (tope < 0)
                        return false;

                    char abierto = pila[tope--];
                    if ((c == ')' && abierto != '(') ||
                        (c == ']' && abierto != '[') ||
                        (c == '}' && abierto != '{'))
                        return false;
                }
            }
            return tope == -1;
        }

        // Implementación de una cola usando dos pilas
        public class ColaConDosPilas<T>
        {
            private Stack<T> pilaEntrada = new Stack<T>();
            private Stack<T> pilaSalida = new Stack<T>();

            // Enqueue: agrega un elemento a la cola
            public void Enqueue(T elemento)
            {
                pilaEntrada.Push(elemento);
            }

            // Dequeue: elimina y retorna el primer elemento de la cola
            public T Dequeue()
            {
                if (pilaSalida.Count == 0)
                {
                    while (pilaEntrada.Count > 0)
                    {
                        pilaSalida.Push(pilaEntrada.Pop());
                    }
                }
                if (pilaSalida.Count == 0)
                    throw new InvalidOperationException("La cola está vacía.");
                return pilaSalida.Pop();
            }

            // Peek: retorna el primer elemento sin eliminarlo
            public T Peek()
            {
                if (pilaSalida.Count == 0)
                {
                    while (pilaEntrada.Count > 0)
                    {
                        pilaSalida.Push(pilaEntrada.Pop());
                    }
                }
                if (pilaSalida.Count == 0)
                    throw new InvalidOperationException("La cola está vacía.");
                return pilaSalida.Peek();
            }

            // Propiedad para saber si la cola está vacía
            public bool IsEmpty => pilaEntrada.Count == 0 && pilaSalida.Count == 0;
        }

        // Método para contar la frecuencia de elementos usando un diccionario
        public static Dictionary<T, int> ContarFrecuencia<T>(IEnumerable<T> elementos)
        {
            var frecuencia = new Dictionary<T, int>();
            foreach (var elemento in elementos)
            {
                if (frecuencia.ContainsKey(elemento))
                    frecuencia[elemento]++;
                else
                    frecuencia[elemento] = 1;
            }
            return frecuencia;
        }
        public static Dictionary<T, int> ContarFrecuenciaManuel<T>(IEnumerable<T> Element)
        {
            var frecuencia = new Dictionary<T, int>();
            foreach (var item in Element)
            {
                if (frecuencia.ContainsKey(item))
                {
                    frecuencia[item]++;
                }
                else
                {
                    frecuencia[item] = 1;
                }
            }
            return frecuencia;
        }

        // Método para verificar si existen duplicados en una colección usando HashSet
        public static bool TieneDuplicados<T>(IEnumerable<T> elementos)
        {
            var conjunto = new HashSet<T>();
            foreach (var elemento in elementos)
            {
                if (!conjunto.Add(elemento))
                    return true; // Se encontró un duplicado
            }
            return false; // No hay duplicados
        }
        // Definición de un nodo para lista enlazada simple
        public class Nodo<T>
        {
            public T Valor;
            public Nodo<T> Siguiente;

            public Nodo(T valor)
            {
                Valor = valor;
                Siguiente = null;
            }
        }

        // Método para revertir una lista enlazada simple
        public static Nodo<T> RevertirListaEnlazada<T>(Nodo<T> cabeza)
        {
            Nodo<T> anterior = null;
            Nodo<T> actual = cabeza;

            while (actual != null)
            {
                Nodo<T> siguiente = actual.Siguiente;
                actual.Siguiente = anterior;
                anterior = actual;
                actual = siguiente;
            }
            return anterior; // Nueva cabeza de la lista invertida
        }
        // Método para detectar si una lista enlazada tiene un ciclo (algoritmo de Floyd)
        public static bool TieneCicloListaEnlazada<T>(Nodo<T> cabeza)
        {
            Nodo<T> lento = cabeza;
            Nodo<T> rapido = cabeza;

            while (rapido != null && rapido.Siguiente != null)
            {
                lento = lento.Siguiente;
                rapido = rapido.Siguiente.Siguiente;

                if (lento == rapido)
                    return true; // Se detectó un ciclo
            }
            return false; // No hay ciclo
        }
        // Fibonacci modificado: devuelve los primeros n números de Fibonacci que cumplen una condición
        public static List<int> FibonacciModificado(int n, Func<int, bool> condicion)
        {
            var resultado = new List<int>();
            int a = 0, b = 1;

            while (resultado.Count < n)
            {
                if (condicion(a))
                    resultado.Add(a);
                int temp = a + b;
                a = b;
                b = temp;
            }
            return resultado;
        }
        // Método para encontrar todas las combinaciones consecutivas que suman un número dado
        public static List<List<int>> SumasConsecutivas(int[] array, int objetivo)
        {
            var resultado = new List<List<int>>();
            int n = array.Length;

            for (int inicio = 0; inicio < n; inicio++)
            {
                int suma = 0;
                var combinacion = new List<int>();
                for (int fin = inicio; fin < n; fin++)
                {
                    suma += array[fin];
                    combinacion.Add(array[fin]);
                    if (suma == objetivo)
                        resultado.Add(new List<int>(combinacion));
                    else if (suma > objetivo)
                        break;
                }
            }
            return resultado;
        }
        // Método para generar la serie 1, 2, 4, 8, ... hasta n elementos
        public static List<int> SeriePotenciasDeDos(int n)
        {
            var resultado = new List<int>();
            int valor = 1;
            for (int i = 0; i < n; i++)
            {
                resultado.Add(valor);
                valor *= 2;
            }
            return resultado;
        }
        // Ejemplo de manejo de excepciones y casos límite para arreglos vacíos o nulos
        public static int SumaArray(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "El arreglo es nulo.");
            if (array.Length == 0)
                throw new ArgumentException("El arreglo está vacío.", nameof(array));

            int suma = 0;
            foreach (var num in array)
                suma += num;
            return suma;
        }
        // Ejemplo de manejo de excepciones y casos límite para strings vacíos o nulos
        public static int LongitudString(string texto, int maxlength)
        {
            if (texto == null)
                throw new ArgumentNullException(nameof(texto), "El string es nulo.");
            if (texto == "")
                throw new ArgumentException("El string está vacío.", nameof(texto));
            if (texto.Length > maxlength)
                throw new ArgumentException($"El string excede la longitud máxima de {maxlength}.", nameof(texto));

            return texto.Length;
        }
        // Ejemplo de manejo de excepciones para números negativos o fuera de rango
        public static int ObtenerElementoPorIndice(int[] array, int indice)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "El arreglo es nulo.");
            if (array.Length == 0)
                throw new ArgumentException("El arreglo está vacío.", nameof(array));
            if (indice < 0 || indice >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(indice), "El índice está fuera de rango.");

            return array[indice];
        }
        // Ejemplo de manejo de entradas duplicadas o inconsistentes
        public static void ValidarEntradasUnicas<T>(IEnumerable<T> elementos)
        {
            if (elementos == null)
                throw new ArgumentNullException(nameof(elementos), "La colección es nula.");

            var conjunto = new HashSet<T>();
            foreach (var elemento in elementos)
            {
                if (!conjunto.Add(elemento))
                    throw new ArgumentException("La colección contiene elementos duplicados.", nameof(elementos));
            }
        }
        public static int numeroMaximo(int[] array)
        {
            return array.Max();
        }
        public static int numeroMaximo(List<int> list)
        {
            return list.Max();
        }
        public static string[] FiltrarNombres(string[] nombres, Func<string, bool> condicion)
        {
            if (nombres == null)
                throw new ArgumentNullException(nameof(nombres), "El array de nombres es nulo.");
            if (condicion == null)
                throw new ArgumentNullException(nameof(condicion), "La condición es nula.");

            for (int i = 0; i < nombres.Length; i++)
            {
                if (string.IsNullOrEmpty(nombres[i]))
                    throw new ArgumentException($"El nombre en la posición {i} es nulo o vacío.", nameof(nombres));
            }

            return nombres.Where(condicion).ToArray();
        }

    }
}
