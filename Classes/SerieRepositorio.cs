using System;
using System.Collections.Generic;
using PROJETO-DIO2.Series.interface;

namespace PROJETO-DIO2
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> ListaSerie = new List<Serie>;
        
        public void Atualiza(int id, Serie entidade)
        {
            ListaSerie[id] = objeto;
        }
        public void Exclui(int id)
        {
            ListaSerie[id].Excluir();
        }
        public void Insere(Serie entidade)
        {
            ListaSerie.add[objeto];
        }
        public list<Serie> Lista()
        {
            return ListaSerie;
        }
        public int ProximoId()
        {
            return ListaSerie.Count;
        }
        public Serie RetornaPorId()
        {
            return ListaSerie[id];
        }
    }
    
}