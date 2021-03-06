///////////////////////////////////////////////////////////
//  TipoDocuCorrelativo.cs
//  Implementation of the Class DocuVentaCorrelativo
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
	public class DocuVentaCorrelativo {

		private int cCorrelativoActual;
		private int cSerie;
		private int Id;
		public DeliveryOnline.Models.Tienda m_Tienda;
		public DeliveryOnline.Models.TipoDocuVenta m_TipoDocuVenta;

		public DocuVentaCorrelativo(){

		}

		~DocuVentaCorrelativo(){

		}

		public int CodigoId{
			get{
				return Id;
			}
			set{
				Id = value;
			}
		}

		public int CorrelativoActual{
			get{
				return cCorrelativoActual;
			}
			set{
				cCorrelativoActual = value;
			}
		}

		public int Serie{
			get{
				return cSerie;
			}
			set{
				cSerie = value;
			}
		}

	}//end DocuVentaCorrelativo

}//end namespace Models