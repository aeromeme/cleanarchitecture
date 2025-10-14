
namespace TestExam
{
    public interface IDesafioTecnico
    {
        int[] BubbleSort(int[] array);
        int BusquedaBinaria(int[] array, int objetivo);
        Dictionary<string, int> ContarPalabras(string texto);
        int[] EliminarDuplicados(int[] array);
        List<(int, int)> EncontrarParesConSuma(int[] array, int sumaObjetivo);
        bool EsPalindromoCadena(string texto);
        bool EsPrimo(int numero);
        int FactorialIterativo(int n);
        int FactorialRecursivo(int n);
        int FibonacciIterativo(int n);
        int FibonacciRecursivo(int n);
        int FormarNumeroMayor(int[] digitos);
        int KEsimoMayor(int[] array, int k);
        int KEsimoMenor(int[] array, int k);
        int[] MoverCerosAlFinal(int[] array);
        int[] RevertirArray(int[] array);
        bool SonAnagramas(string texto1, string texto2);
        bool SonAnagramasPorOrden(string texto1, string texto2);
    }
}