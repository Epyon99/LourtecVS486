///////////////////////////////////////////////////////////
//  DetallePedido.cs
//  Implementation of the Class DetallePedido
//  Generated by Enterprise Architect
//  Created on:      30-Set.-2017 12:37:43
//  Original author: Enrique
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using DeliveryOnline.Models;
namespace DeliveryOnline.Models {
	public class DetallePedido {
        private int nId; //IdPedido
		private int nCantidad;
		private int nEstado;
		private Double nPrecio;
		public DeliveryOnline.Models.Producto m_Producto;

		public DetallePedido(){

		}

		~DetallePedido(){

		}

        public int Id
        {
            get
            {
                return nId;
            }
            set
            {
                nId = value;
            }
        }

        public int Cantidad{
			get{
				return nCantidad;
			}
			set{
				nCantidad = value;
			}
		}

		public int Estado{
			get{
				return nEstado;
			}
			set{
				nEstado = value;
			}
		}

		public Double Precio{
			get{
				return nPrecio;
			}
			set{
				nPrecio = value;
			}
		}

		/// 
		/// <param name="ncantidad"></param>
		/// <param name="nprecio"></param>
		public int SubTotal(int ncantidad, double nprecio){

			return 0;
		}

	}//end DetallePedido

}//end namespace Models