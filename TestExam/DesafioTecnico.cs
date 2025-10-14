namespace TestExam
{
    public class DesafioTecnico : IDesafioTecnico
    {
        // Método para invertir un array sin usar funciones integradas
        public int[] RevertirArray(int[] array)
        {
            int n = array.Length;
            int[] resultado = new int[n];
            for (int i = 0; i < n; i++)
            {
                resultado[i] = array[n - 1 - i];
            }
            return resultado;
        }

        // Método para mover todos los ceros al final manteniendo el orden relativo
        public int[] MoverCerosAlFinal(int[] array)
        {
            int n = array.Length;
            int[] resultado = new int[n];
            int index = 0;

            // Copiar los elementos distintos de cero
            for (int i = 0; i < n; i++)
            {
                if (array[i] != 0)
                {
                    resultado[index++] = array[i];
                }
            }

            // Los ceros ya están en el resto del array (por defecto inicializados en cero)
            return resultado;
        }

        // Método para eliminar duplicados y devolver un array con elementos únicos
        public int[] EliminarDuplicados(int[] array)
        {
            int n = array.Length;
            int[] temp = new int[n];
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                bool encontrado = false;
                for (int j = 0; j < count; j++)
                {
                    if (array[i] == temp[j])
                    {
                        encontrado = true;
                        break;
                    }
                }
                if (!encontrado)
                {
                    temp[count++] = array[i];
                }
            }

            int[] resultado = new int[count];
            for (int i = 0; i < count; i++)
            {
                resultado[i] = temp[i];
            }
            return resultado;
        }

        // Método para verificar si una cadena es palíndromo
        public bool EsPalindromoCadena(string texto)
        {
            int n = texto.Length;
            for (int i = 0; i < n / 2; i++)
            {
                if (texto[i] != texto[n - 1 - i])
                {
                    return false;
                }
            }
            string s = "text";
            var data=texto.ToCharArray();
            var reverse = data.Reverse();
            string nueva = reverse.ToString();
            return true;
        }

        // Método para contar palabras y devolver un diccionario con el conteo de cada palabra
        public Dictionary<string, int> ContarPalabras(string texto)
        {
            var diccionario = new Dictionary<string, int>();
            int inicio = 0;
            int longitud = texto.Length;

            for (int i = 0; i <= longitud; i++)
            {
                if (i == longitud || char.IsWhiteSpace(texto[i]))
                {
                    if (inicio < i)
                    {
                        string palabra = texto.Substring(inicio, i - inicio);
                        if (diccionario.ContainsKey(palabra))
                        {
                            diccionario[palabra]++;
                        }
                        else
                        {
                            diccionario[palabra] = 1;
                        }
                    }
                    inicio = i + 1;
                }
            }

            return diccionario;
        }

        // Método para verificar si dos cadenas son anagramas entre sí
        public bool SonAnagramas(string texto1, string texto2)
        {
            if (texto1.Length != texto2.Length)
                return false;

            int[] conteo = new int[256]; // Asume ASCII extendido

            for (int i = 0; i < texto1.Length; i++)
            {
                conteo[(int)texto1[i]]++;
                conteo[(int)texto2[i]]--;
            }

            for (int i = 0; i < conteo.Length; i++)
            {
                if (conteo[i] != 0)
                    return false;
            }

            return true;
        }

        // Método alternativo para verificar si dos cadenas son anagramas (ordenando manualmente)
        public bool SonAnagramasPorOrden(string texto1, string texto2)
        {
            if (texto1.Length != texto2.Length)
                return false;

            char[] arr1 = new char[texto1.Length];
            char[] arr2 = new char[texto2.Length];

            for (int i = 0; i < texto1.Length; i++)
                arr1[i] = texto1[i];
            for (int i = 0; i < texto2.Length; i++)
                arr2[i] = texto2[i];

            // Ordenamiento manual tipo burbuja
            for (int i = 0; i < arr1.Length - 1; i++)
            {
                for (int j = 0; j < arr1.Length - i - 1; j++)
                {
                    if (arr1[j] > arr1[j + 1])
                    {
                        char temp = arr1[j];
                        arr1[j] = arr1[j + 1];
                        arr1[j + 1] = temp;
                    }
                    if (arr2[j] > arr2[j + 1])
                    {
                        char temp = arr2[j];
                        arr2[j] = arr2[j + 1];
                        arr2[j + 1] = temp;
                    }
                }
            }

            // Comparar los arreglos ordenados
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }
            return true;
        }

        // Método para verificar si un número es primo
        public bool EsPrimo(int numero)
        {
            if (numero < 2)
                return false;

            for (int i = 2; i * i <= numero; i++)
            {
                if (numero % i == 0)
                    return false;
            }
            return true;
        }

        // Factorial iterativo
        public int FactorialIterativo(int n)
        {
            int resultado = 1;
            for (int i = 2; i <= n; i++)
            {
                resultado *= i;
            }
            return resultado;
        }

        // Factorial recursivo
        public int FactorialRecursivo(int n)
        {
            if (n <= 1)
                return 1;
            return n * FactorialRecursivo(n - 1);
        }

        // Fibonacci iterativo
        public int FibonacciIterativo(int n)
        {
            if (n <= 1)
                return n;
            int a = 0, b = 1;
            for (int i = 2; i <= n; i++)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }
            return b;
        }

        // Fibonacci recursivo
        public int FibonacciRecursivo(int n)
        {
            if (n <= 1)
                return n;
            return FibonacciRecursivo(n - 1) + FibonacciRecursivo(n - 2);
        }

        // Método para encontrar pares en un array que sumen un valor dado
        public List<(int, int)> EncontrarParesConSuma(int[] array, int sumaObjetivo)
        {
            var resultado = new List<(int, int)>();
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (array[i] + array[j] == sumaObjetivo)
                    {
                        resultado.Add((array[i], array[j]));
                    }
                }
            }

            return resultado;
        }

        // Método para formar el número mayor posible a partir de un array de dígitos
        public int FormarNumeroMayor(int[] digitos)
        {
            int n = digitos.Length;

            // Ordenamiento manual tipo burbuja en orden descendente
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (digitos[j] < digitos[j + 1])
                    {
                        int temp = digitos[j];
                        digitos[j] = digitos[j + 1];
                        digitos[j + 1] = temp;
                    }
                }
            }

            int resultado = 0;
            for (int i = 0; i < n; i++)
            {
                resultado = resultado * 10 + digitos[i];
            }
            return resultado;
        }

        // Método para buscar un número en un array ordenado usando búsqueda binaria
        public int BusquedaBinaria(int[] array, int objetivo)
        {
            int izquierda = 0;
            int derecha = array.Length - 1;

            while (izquierda <= derecha)
            {
                int medio = izquierda + (derecha - izquierda) / 2;

                if (array[medio] == objetivo)
                    return medio;
                else if (array[medio] < objetivo)
                    izquierda = medio + 1;
                else
                    derecha = medio - 1;
            }
            return -1; // No encontrado
        }

        // Método para ordenar un array usando bubble sort
        public int[] BubbleSort(int[] array)
        {
            int n = array.Length;
            int[] resultado = new int[n];
            for (int i = 0; i < n; i++)
                resultado[i] = array[i];

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (resultado[j] > resultado[j + 1])
                    {
                        int temp = resultado[j];
                        resultado[j] = resultado[j + 1];
                        resultado[j + 1] = temp;
                    }
                }
            }
            return resultado;
        }



        // Método para encontrar el k-ésimo mayor elemento en un array
        public int KEsimoMayor(int[] array, int k)
        {
            int n = array.Length;
            int[] copia = new int[n];
            for (int i = 0; i < n; i++)
                copia[i] = array[i];

            // Ordenamiento burbuja descendente
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (copia[j] < copia[j + 1])
                    {
                        int temp = copia[j];
                        copia[j] = copia[j + 1];
                        copia[j + 1] = temp;
                    }
                }
            }

            // k debe ser 1-based (1 = mayor, 2 = segundo mayor, ...)
            if (k < 1 || k > n)
                throw new ArgumentOutOfRangeException(nameof(k), "k debe estar entre 1 y el tamaño del array.");

            return copia[k - 1];
        }

        // Método para encontrar el k-ésimo menor elemento en un array
        public int KEsimoMenor(int[] array, int k)
        {
            int n = array.Length;
            int[] copia = new int[n];
            for (int i = 0; i < n; i++)
                copia[i] = array[i];

            // Ordenamiento burbuja ascendente
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (copia[j] > copia[j + 1])
                    {
                        int temp = copia[j];
                        copia[j] = copia[j + 1];
                        copia[j + 1] = temp;
                    }
                }
            }

            // k debe ser 1-based (1 = menor, 2 = segundo menor, ...)
            if (k < 1 || k > n)
                throw new ArgumentOutOfRangeException(nameof(k), "k debe estar entre 1 y el tamaño del array.");

            return copia[k - 1];
        }
    }
}
