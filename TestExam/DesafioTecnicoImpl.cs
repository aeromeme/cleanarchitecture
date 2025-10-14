using Restaurant.Entities;

public class DesafioTecnicoImpl {

    public int[] RevertirArray(int[] array){
        var len= array.Length;
        var resultado = new int[len];
        for(int i=0; i<len;i++){
            resultado[i]=array[len-1-i];
        }
        return resultado;
    }
    public Dictionary<string,int> ContarPalabras(string text){
        var len=text.Length;
        var inicioPalabra=0;
        var resultado = new Dictionary<string,int>();
        for (int i =0 ; i<=len;i++){
            if (i==len || text[i] == ' ')
            {
                var palabra= text.Substring(inicioPalabra,i-inicioPalabra);
                if (resultado.ContainsKey(palabra))
                    resultado[palabra]++;
                if (!resultado.ContainsKey(palabra))
                    resultado[palabra]=1;
                inicioPalabra=i+1;
            }
            
        }
        return resultado;
    }
    public int[] MoverCerosAlFinal(int[] array){
        var len = array.Length;
        var resultado = new int[len];
        var index =0;
        for (var i =1; i<len;i++){
           if (array[i]!=0){
                resultado[index++]=array[i];
           }
            
        }
        return resultado;
    }
    public int[] EliminarDuplicados(int[] array){
        var unicos= new HashSet<int>();
        foreach ( var item in array){
            unicos.Add(item);
        }
        var resultado = new int [unicos.Count];
        for(int i = 0; i<unicos.Count; i++){
            resultado[i] = unicos.ElementAt(i);
        }
        return array.Distinct().ToArray();
        return resultado;
    }
    public  bool EsPalindromoCadena(string texto){
        var len = texto.Length;
        var reflejo="";
        var chars = new char[len];
        for (int i =0; i<len; i++){
            chars[i]=texto[len-1-i];
        }
        foreach (var item in chars) { 
            reflejo+=item;
        }
        if (reflejo==texto){
            return true;
        }
        return false;
        
    }
    public bool EsPrimo (int numero){
        if(numero<2)
            return true;
        for(int i=2; i*i<numero;i++){

            if (numero%i==0){
                return false;
            }
        }
        return true;
    }
    public int FactorialIterativo(int n){
        int resultado=1;
        for(int i=2; i<=n;i++){
            resultado*=i;
        }
        return resultado;
    }
    public int FibonacciIterativo(int n){
        int a= 0;
        int b=1;
        int temp=0;
        for(int i=2; i<=n; i++){
            temp=a+b;
            a=b;
            b=temp;
        }
        return b;
    }
    public List<(int,int)> EncontrarParesConSuma(int[] array, int objetivo){
        var len= array.Length;
        var resultado= new List<(int,int)>();
        for(int i=0; i<len-1;i++){
            for (int j=i+1; j<len;j++ ){
                if(array[i]+array[j]==objetivo){
                    resultado.Add((array[i],array[j]));
                }
            }
        }
        return resultado;
    }
    public int FormarNumeroMayor(int[] array){
        var len= array.Length;
        var temp=0;
        for(int i=0; i< len-1;i++){
            for (int j=0; j<len-1;j++){

                if (array[j]<array[j+1]){
                    temp=array[j+1];
                    array[j+1]=array[j];
                    array[j]=temp;
                }
            }
        }
        var resultado = 0;
        foreach(int item in array){
           resultado*=10;
           resultado+=item;
        }
        return resultado;
    }
     public int BusquedaBinaria(int[] array, int objetivo){

        int izquierda=0;
        int derecha= array.Length-1;
        while (true){
            if(array[izquierda]==objetivo){
                return izquierda;
            }
            if(array[derecha]==objetivo){
                return derecha;
            }
            izquierda++;
            derecha--;
        }
        return -1;
     }

     public int[] BubbleSort(int[] array){
        int n= array.Length;
        int[] resultado=array.ToArray();
        for(int i=0; i<n-1; i++){
            for(int j=0; j<n-1;j++){
                if (resultado[j]>resultado[j+1]){
                    var temp=resultado[j];
                    resultado[j]=resultado[j+1];
                    resultado[j+1]=temp;
                }
            }
        }
        return resultado;

     }
      public int KEsimoMayor(int[] array, int k){
        var ordenado= BubbleSort(array);
        var n= array.Length;
        if (k<1 ||k>n)
            throw new ArgumentOutOfRangeException(nameof(k),"k debe estar en 1 y el tamaño del array");
        return ordenado[k-1];
      }

     public  Dictionary<T, int> ContarFrecuencia<T>(IEnumerable<T> elementos){
            var n= elementos.Count();
            var resultado= new Dictionary<T,int>();
            foreach(var item in elementos){
                if(resultado.ContainsKey(item)){
                    resultado[item]++;
                }else{
                    resultado[item]=1;
                }
            }
            return resultado;

        }

         public  bool TieneDuplicados<T>(IEnumerable<T> elementos){

            var lista= new HashSet<T>();
            foreach(var item in elementos){
                if (!lista.Add(item)){
                    return true;
                }
            }
            return false;
         }

        // Fibonacci modificado: devuelve los primeros n números de Fibonacci que cumplen una condición
          public  List<int> FibonacciModificado(int n, Func<int, bool> condicion){
             int a=0;
             int b=1;
             int temp=0;
             var resultado= new List<int>();
             if (condicion(a)){
                resultado.Add(0);
             }
             if (condicion(b)){
                resultado.Add(1);
             }
            while(resultado.Count()<n){
                temp=a+b;
                if (condicion(temp)){
                    resultado.Add(temp);
                }
                a=b;
                b=temp;
             }
             return resultado;
          }

          public List<List<int>> SumasConsecutivas (int[] array, int suma){
            var n= array.Length;
            var resultado = new List<List<int>>();
            var sumaconsecutiva=0;
            for (int i =0; i<n-1;i++){
                var sumandos = new List<int>();
                sumandos.Add(array[i]);
                sumaconsecutiva=array[i];
                for (int j=i+1;j<n;j++){
                    sumaconsecutiva+=array[j];
                    sumandos.Add(array[j]);
                    if (sumaconsecutiva>=suma){
                        resultado.Add(sumandos);
                        break;
                    }

                }
            }
            return resultado;

          }

          public List<int> SeriePotenciasDeDos(int n){
            var resultado= new List<int>();
            var potenciadedos=1;
            resultado.Add(potenciadedos);
            for(int i=1; i<n;i++){
                resultado.Add(potenciadedos*=2);
            }
            return resultado;
          }


          public int SumaArray(int[] datos){
            if (datos==null){
                throw new ArgumentNullException(nameof(datos),"no puede ser nul");
            }
            if (datos.Count()==0){
                throw new ArgumentException("debe traer datos",nameof(datos));
            }
            var resultado=0;
            foreach(var item in datos){
                resultado+=item;
            }
            return resultado;

          }

          public int LongitudString(string x,int maxlenght){
            if(x==null)
                throw new ArgumentNullException(nameof(x),"la cadena debe tener datos");
            if(x=="")
                throw new ArgumentException("La cadena no puede estar vacia",nameof(x));
            var resultado=x.Length;
            if(resultado>maxlenght)
                throw new ArgumentException("La cadena supera la longitud maxima",nameof(x));
            return x.Length;
            
          }
          public int ObtenerElementoPorIndice(int[] array,int ix){
           
            if(array==null)
                throw new ArgumentNullException(nameof(array),"el array es null");
            if(array.Count()==0)
                throw new ArgumentException("El array esta vacio",nameof(array));
             var n = array.Length;
            if(n-1<ix || ix<0)
                throw new ArgumentOutOfRangeException("indice fuera",nameof(ix));
            return array[ix];
          }
          public void ValidarEntradasUnicas<T>(T[] array){
            if(array==null)
                throw new ArgumentNullException(nameof(array),"el array es null");
            if(array.Count()==0)
                throw new ArgumentException("El array esta vacio",nameof(array));
            var unicas= new HashSet<T>();
            foreach(var item in array){
                if (!unicas.Add(item))
                    throw new ArgumentException("los elementos del array no son unicos",nameof(array));

            }
          }

          public string[] FiltrarNombres (string[] nombres, Func<string,bool> condicion){
            if(nombres==null)
                throw new ArgumentNullException(nameof(nombres),"el array es null");
            if(condicion==null)
                throw new ArgumentNullException(nameof(condicion),"la condicion no puede ser nula");
            if(nombres.Count()==0)
                throw new ArgumentException("El array esta vacio",nameof(nombres));
            foreach(var item in nombres){
                if (string.IsNullOrEmpty(item)){
                    throw new ArgumentException(nameof(nombres),"uno de los nombres viene vacio");
                }
            }
            return nombres.Where(condicion).ToArray();
          }
          public decimal CalcularTotalVenta(Sale venta){
            if (venta==null)
                throw new ArgumentNullException(nameof(venta),"la venta es nula");
            if(venta.Products.Count()==0)
                throw new ArgumentNullException(nameof(venta),"la venta no tiene productos");
            return venta.Products.Sum(p=>p.Price);
          }
          public List<Sale> FiltrarVentasSinProductos(List<Sale> ventas){
            if (ventas==null)
                throw new ArgumentNullException(nameof(ventas),"la ventas son nula");
            return ventas.Where(v=>v.Products!=null && v.Products.Count()>0).ToList();

          }
          public Product ProductoMasVendido(List<Sale> ventas){
             if (ventas==null)
                throw new ArgumentNullException(nameof(ventas),"la ventas son nula");
            Dictionary<Product,int> contador= new ();
            foreach(var venta in ventas){
                foreach(var producto in venta.Products){
                    if (contador.ContainsKey(producto)){
                        contador[producto]++;
                    }
                    else{
                        contador[producto]=1;
                    }
                }
            }
        return contador.MaxBy(x => x.Value).Key;
            return contador.OrderByDescending(kv => kv.Value).FirstOrDefault().Key;
          }

          public decimal TotalVendido(List<Sale> ventas){
        if (ventas == null)
            throw new ArgumentNullException(nameof(ventas), "la ventas son nula");
            return ventas.Sum(v=>v.GetTotal());

          }
          
		  public decimal TotalVendidoPorProducto(List<Sale> ventas, Product p){
			  
			if (ventas == null)
				throw new ArgumentNullException(nameof(ventas), "la ventas son nula");
			if (p == null)
				throw new ArgumentNullException(nameof(p), "el producto es nulo");
			return ventas.SelectMany(v=>v.Products).Where(i=>i==p).Sum(i=>i.Price);
			
		  }



}