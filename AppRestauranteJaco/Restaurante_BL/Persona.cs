﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Restaurante_BL
{
    //db.CajaDiarias.InsertOnSubmit(_NewGasto);

    //db.SubmitChanges();
    public class Persona
    {
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Ident_Tipo { get; set; }
        public string Ident_Numero { get; set; }
        public string NombreComercial { get; set; }
        public string Ubi_Provicia { get; set; }
        public string Ubi_Canton { get; set; }
        public string Ubi_Distrito { get; set; }
        public string Ubi_OtrasSenas { get; set; }
        public string Tel_CodigoPais { get; set; }
        public string Tel_NumeroTelefono { get; set; }
        public string Fax_CodigoPais { get; set; }
        public string Fax_NumeroTelefono { get; set; }
        public string CorreoElectronico { get; set; }


        Restaurante_DAL.BaseDatosDataContext db = null;
        public Persona()
        {

        }

        public Persona(Restaurante_DAL.Persona per)
        {
            this.Nombre = per.Nombre;
            this.Rol = per.Rol;
            this.Ident_Tipo = per.Ident_Tipo;
            this.Ident_Numero = per.Ident_Numero;
            this.NombreComercial = per.NombreComercial;
            this.Ubi_Provicia = per.Ubi_Provicia;
            this.Ubi_Distrito = per.Ubi_Distrito;
            this.Ubi_OtrasSenas = per.Ubi_OtrasSenas;
            this.Ubi_Canton = per.Ubi_Canton;
            this.Tel_CodigoPais = per.Tel_CodigoPais;
            this.Tel_NumeroTelefono = per.Tel_NumeroTelefono;
            this.Fax_CodigoPais = per.Fax_CodigoPais;
            this.Fax_NumeroTelefono = per.Fax_NumeroTelefono;
            this.CorreoElectronico = per.CorreoElectronico;
        }
        public void OpenConn()
        {
            if (db == null) db = new Restaurante_DAL.BaseDatosDataContext();
        }

        public bool AgregarPersona(Persona per, bool emisor)
        {
            var emi = Cargar_Emmisor();
            if ((emi == null && emisor) || (!emisor))
            {
                this.OpenConn();
                Restaurante_DAL.Persona persona = new Restaurante_DAL.Persona();
                //Datos alambrados 
                persona.Tel_CodigoPais = "506";
                persona.Fax_CodigoPais = "506";
                persona.NombreComercial = "";
                persona.Rol = "";

                //Validacion de emisor
                persona.Receptor = !emisor;
                persona.Emisor = emisor;

                //Datos a dinamicos
                persona.CorreoElectronico = per.CorreoElectronico;
                persona.Ident_Numero = per.Ident_Numero;
                persona.Ident_Tipo = per.Ident_Tipo;
                persona.Nombre = per.Nombre;
                persona.Tel_NumeroTelefono = per.Tel_NumeroTelefono;
                persona.Fax_NumeroTelefono = per.Fax_NumeroTelefono;
                persona.Ubi_Canton = per.Ubi_Canton;
                persona.Ubi_Distrito = per.Ubi_Distrito;
                persona.Ubi_OtrasSenas = per.Ubi_OtrasSenas;
                persona.Ubi_Provicia = per.Ubi_Provicia;
                try
                {
                    db.Persona.InsertOnSubmit(persona);
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void Cargar_Personas(DataGridView dgv)
        {
            this.OpenConn();
            var bus = db.Persona.Select(x => x);

            if (bus.Count() > 0)
            {
                dgv.DataSource = bus;
            }
        }

        public Persona Cargar_Receptor(string ced)
        {
            this.OpenConn();
            Restaurante_DAL.Persona bus = db.Persona.Where(n => n.Ident_Numero == ced && n.Receptor == true).Select(n => n).FirstOrDefault();
            if (bus != null)
            {
                Persona per = new Persona(bus);
                return per;
            }
            else
            {
                return null;
            }
        }

        public Persona Cargar_Emmisor()
        {
            this.OpenConn();
            Restaurante_DAL.Persona bus = db.Persona.Where(n => n.Emisor == true).Select(n => n).FirstOrDefault();
            if (bus != null)
            {
                Persona per = new Persona(bus);
                return per;
            }
            else
            {
                return null;
            }
        }

        public bool Eliminar_Persona(string cedula)
        {
            this.OpenConn();
            Restaurante_DAL.Persona bus = db.Persona.Where(n => n.Ident_Numero == cedula).Select(n => n).FirstOrDefault();
            try
            {
                db.Persona.DeleteOnSubmit(bus);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public List<Restaurante_DAL.Persona> load_Receptores()
        {
            OpenConn();
            return db.Persona.Where(x => x.Receptor == true).ToList();

        }
    }


}
