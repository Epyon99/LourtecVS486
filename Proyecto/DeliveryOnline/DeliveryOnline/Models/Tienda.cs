///////////////////////////////////////////////////////////
//  Tienda.cs
//  Implementation of the Class Tienda
//  Generated by Enterprise Architect
//  Created on:      30-Set.-2017 12:37:43
//  Original author: Enrique Incio Ch.
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using DeliveryOnline.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Web.Mvc;

namespace DeliveryOnline.Models {
    [Serializable]
	public class Tienda {

		private string cDireccion;
		private string cNombreComercial;
		private string cRazonSocial;
		private string cTelefono;
		private DateTime dFechaRegsitro;
		private int Id = 0;
		private int nEstado;
		//public DeliveryOnline.Models.TiendaProducto m_TiendaProducto;
        public virtual ICollection<Producto> Productos { get; set; }
		//public DeliveryOnline.Models.TiendaUsuario m_TiendaUsuario;
        public virtual ICollection<Persona> Usuarios { get; set; }
		public Tienda(){

		}

		~Tienda(){

		}

        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CodigoId{
			get{
				return Id;
			}
			set{
				Id = value;
			}
		}

        [Required()]
        [StringLength(500)]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
		public string Direccion{
			get{
				return cDireccion;
			}
			set{
				cDireccion = value;
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

		public DateTime FechaRegsitro{
			get{
				return dFechaRegsitro;
			}
			set{
				dFechaRegsitro = value;
			}
		}

        [DisplayName("Nombre Comercial")]
        [Required]
        [StringLength(100)]
		public string NombreComercial{
			get{
				return cNombreComercial;
			}
			set{
				cNombreComercial = value;
			}
		}

        [DisplayName("Razon Social")]
        [Required]
		public string RazonSocial{
			get{
				return cRazonSocial;
			}
			set{
				cRazonSocial = value;
			}
		}

        [DataType(DataType.PhoneNumber)]
		public string Telefono{
			get{
				return cTelefono;
			}
			set{
				cTelefono = value;
			}
		}

	}//end Tienda

}//end namespace Models