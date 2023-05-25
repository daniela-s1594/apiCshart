﻿using App_API_DMV.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace App_API_DMV.Data
{
    public class UsuarioData
    {

        public static bool registrarUsuario(Usuario oUsuario)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE usp_registrar '" +
            oUsuario.IdU + "','" + oUsuario.Nombres + "',' " +
            oUsuario.Telefono + "','" + oUsuario.Correo + "','" + oUsuario.Ciudad + "'";
            if (!objEst.EjecutarSentencia(sentencia, false))
            {
                objEst = null;
                return false;
            }
            else
            {
                objEst = null;
                return true;
            }
        }
        public static bool actualizarUsuario(Usuario oUsuario)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE usp_actualizar '" +
            oUsuario.IdU + "','" + oUsuario.Nombres + "','" +
            oUsuario.Telefono + "','" + oUsuario.Correo + "','" +
            oUsuario.Ciudad + "'";
            if (!objEst.EjecutarSentencia(sentencia, false))
            {
                objEst = null;
                return false;
            }
            else
            {
                objEst = null;
                return true;
            }
        }
        public static bool eliminarUsuario(string id)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE usp_Eliminar '" + id + "'";
            if (!objEst.EjecutarSentencia(sentencia, false))
            {
                objEst = null;
                return false;
            }
            else
            {
                objEst = null;
                return true;
            }
        }
        public static List<Usuario> Listar()
        {
            List<Usuario> oListaUsuario = new List<Usuario>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE usp_listar";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    oListaUsuario.Add(new Usuario()
                    {
                        IdU = Convert.ToInt32(dr["IdU"]),
                        Nombres = dr["Nombres"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Ciudad = dr["Ciudad"].ToString(),
                        FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"].ToString())
                    });
                }
                return oListaUsuario;
            }
            else
            {
                return oListaUsuario;
            }
        }
        public static List<Usuario> Obtener(string id)
        {
            List<Usuario> oListaUsuario = new List<Usuario>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE usp_obtener '" + id + "'";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    oListaUsuario.Add(new Usuario()
                    {
                        IdU = Convert.ToInt32(dr["IdU"]),
                        Nombres = dr["Nombres"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Ciudad = dr["Ciudad"].ToString(),
                        FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"].ToString())
                    });
                }
                return oListaUsuario;
            }
            else
            {
                return oListaUsuario;
            }
        }
    }
}