///////////////////////////////////////////////////////////
//  Pedido.cs
//  Implementation of the Class Pedido
//  Generated by Enterprise Architect
//  Created on:      30-Set.-2017 12:37:43
//  Original author: Enrique
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using DeliveryOnline.Models;
using System.ComponentModel.DataAnnotations;

namespace DeliveryOnline.Models {
	public class Pedido {

		private DateTime dFechaHoraEntrega;
		private DateTime dFechaHoraRegistro;
		private int Id;
		private int nEstado;
		public DeliveryOnline.Models.DetallePedido m_DetallePedido;
		public DeliveryOnline.Models.Persona m_Persona;

		public Pedido(){

		}

		~Pedido(){

		}

        [Key]
		public int CodigoId{
			get{
				return Id;
			}
			set{
				Id = value;
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

		public DateTime FechaHoraEntrega{
			get{
				return dFechaHoraEntrega;
			}
			set{
				dFechaHoraEntrega = value;
			}
		}

		public DateTime FechaHoraRegistro{
			get{
				return dFechaHoraRegistro;
			}
			set{
				dFechaHoraRegistro = value;
			}
		}

	}//end Pedido

}//end namespace Models