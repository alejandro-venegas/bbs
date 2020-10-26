using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bbs.Models;
using bbs.DTOs;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Text;
using System;
using System.Linq;
namespace bbs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraficasController : Controller
    {
        private readonly SBBSContext _context;
        private SqlConnectionStringBuilder builder;

        public GraficasController(SBBSContext context)
        {
            _context = context;
            builder = new SqlConnectionStringBuilder();

            
            builder.ConnectionString = "Server=DESKTOP-8PDO96H;Database=SBBS;Trusted_Connection=True;";
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGrafica(int id)
        {

            return StatusCode(400);
        }
        [HttpGet]
        public async Task<IActionResult> GetGraficas(string tipoGraficas, string propiedad, DateTime startDate, DateTime endDate)
    
        {
            
            
            List<string> tiposGraficas = tipoGraficas.Split(",").ToList();
            List<dynamic> resultArray = new List<dynamic>();
            try
            {

                dynamic result = 1;

        

                
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    foreach (string tipoGrafica in tiposGraficas)
                    {
                        var dataDictionary = new Dictionary<dynamic, dynamic>();
                        dataDictionary.Add("dataSet", tipoGrafica);
                        switch (tipoGrafica)
                        {
                            case "incidente":
                                switch (propiedad)
                                {
                                    case "dia":

                                        connection.Open();

                                        using (SqlCommand command = new SqlCommand("Select DatePart(dw,Fecha) as dia, count(*) as cantidad from Incidentes group by DatePart(dw,Fecha);", connection))
                                        {
                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                result = new List<dynamic>();
                                                while (reader.Read())
                                                {
                                                    String label;
                                                    switch (reader.GetInt32(0))
                                                    {
                                                        case 1:
                                                            label = "Dom";
                                                            break;
                                                        case 2:
                                                            label = "Lun";
                                                            break;
                                                        case 3:
                                                            label = "Mar";
                                                            break;
                                                        case 4:
                                                            label = "Mie";
                                                            break;
                                                        case 5:
                                                            label = "Jue";
                                                            break;
                                                        case 6:
                                                            label = "Vie";
                                                            break;
                                                        case 7:
                                                            label = "Sáb";
                                                            break;
                                                        default:
                                                            label = "No definido";
                                                            break;
                                                    }

                                                    result.Add(new { Label = label, count = reader.GetInt32(1) });
                                                }
                                            }
                                        }
                                        break;
                                    case "semana":
                                        result = new List<dynamic>();
                                        connection.Open();
                                        using (SqlCommand command = new SqlCommand("Select DatePart(wk,Fecha) as dia, count(*) as cantidad from Incidentes group by DatePart(wk,Fecha);", connection))
                                        {
                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                while (reader.Read())
                                                {


                                                    result.Add(new { Label = reader.GetInt32(0), count = reader.GetInt32(1) });
                                                }
                                            }
                                        }
                                        break;

                                    case "mes":


                                        result = await _context.Incidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .GroupBy(p => p.Fecha.Month)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();

                                        break;
                                    case "proceso":
                                        result = await _context.Incidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate  )
                                        .Include(p => p.Proceso)
                                        .GroupBy(p => p.Proceso.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;
                                    case "nivel-de-riesgo":
                                        result = await _context.Incidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Riesgo)
                                        .GroupBy(p => p.Riesgo.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;

                                    case "area-de-trabajo":
                                        result = await _context.Incidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Area)
                                        .GroupBy(p => p.Area.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;
                                    case "genero":
                                        result = await _context.Incidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Genero)
                                        .GroupBy(p => p.Genero.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;
                                    case "tipo-de-efecto":
                                        result = await _context.Incidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Efecto)
                                        .GroupBy(p => p.Efecto.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;
                                    case "clasificacion":
                                        result = await _context.Incidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Clasificacion)
                                        .GroupBy(p => p.Clasificacion.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;
                                    case "turno":
                                        result = await _context.Incidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Turno)
                                        .GroupBy(p => p.Turno.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;
                                    case "parte-afectada":
                                        result = await _context.Incidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.ParteCuerpo)
                                        .GroupBy(p => p.ParteCuerpo.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;
                                    case "causa-basica":
                                        result = await _context.Incidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.CausaBasica)
                                        .GroupBy(p => p.CausaBasica.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;
                                    case "causa-inmediata":
                                        result = await _context.Incidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.CausaInmediata)
                                        .GroupBy(p => p.CausaInmediata.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;
                                    default:

                                        return StatusCode(404);


                                }
                                break;
                            case "casi-incidente":
                                switch (propiedad)
                                {
                                    case "dia":

                                        connection.Open();

                                        using (SqlCommand command = new SqlCommand("Select DatePart(dw,Fecha) as dia, count(*) as cantidad from CasiIncidentes group by DatePart(dw,Fecha);", connection))
                                        {
                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                result = new List<dynamic>();
                                                while (reader.Read())
                                                {
                                                    String label;
                                                    switch (reader.GetInt32(0))
                                                    {
                                                        case 1:
                                                            label = "Dom";
                                                            break;
                                                        case 2:
                                                            label = "Lun";
                                                            break;
                                                        case 3:
                                                            label = "Mar";
                                                            break;
                                                        case 4:
                                                            label = "Mie";
                                                            break;
                                                        case 5:
                                                            label = "Jue";
                                                            break;
                                                        case 6:
                                                            label = "Vie";
                                                            break;
                                                        case 7:
                                                            label = "Sáb";
                                                            break;
                                                        default:
                                                            label = "No definido";
                                                            break;
                                                    }

                                                    result.Add(new { Label = label, count = reader.GetInt32(1) });
                                                }
                                            }
                                        }
                                        break;
                                    case "semana":
                                        result = new List<dynamic>();
                                        connection.Open();
                                        using (SqlCommand command = new SqlCommand("Select DatePart(wk,Fecha) as dia, count(*) as cantidad from CasiIncidentes group by DatePart(wk,Fecha);", connection))
                                        {
                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                while (reader.Read())
                                                {


                                                    result.Add(new { Label = reader.GetInt32(0), count = reader.GetInt32(1) });
                                                }
                                            }
                                        }
                                        break;

                                    case "mes":


                                        result = await _context.CasiIncidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .GroupBy(p => p.Fecha.Month)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();

                                        break;
                                    case "proceso":
                                        result = await _context.CasiIncidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Proceso)
                                        .GroupBy(p => p.Proceso.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;
                                    case "nivel-de-riesgo":
                                        result = await _context.CasiIncidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Riesgo)
                                        .GroupBy(p => p.Riesgo.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;

                                    case "area-de-trabajo":
                                        result = await _context.CasiIncidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Area)
                                        .GroupBy(p => p.Area.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;
                                    case "genero":
                                        result = await _context.CasiIncidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Genero)
                                        .GroupBy(p => p.Genero.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;

                                    case "turno":
                                        result = await _context.CasiIncidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Turno)
                                        .GroupBy(p => p.Turno.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;

                                    case "casualidad":
                                        result = await _context.CasiIncidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Casualidad)
                                        .GroupBy(p => p.Casualidad.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;

                                    case "jornada":
                                        result = await _context.CasiIncidentes
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Jornada)
                                        .GroupBy(p => p.Jornada.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;


                                    default:

                                        return StatusCode(404);


                                }
                                break;
                            case "bbs":
                                switch (propiedad)
                                {
                                    case "dia":

                                        connection.Open();

                                        using (SqlCommand command = new SqlCommand("Select DatePart(dw,Fecha) as dia, count(*) as cantidad from Bbss group by DatePart(dw,Fecha);", connection))
                                        {
                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                result = new List<dynamic>();
                                                while (reader.Read())
                                                {
                                                    String label;
                                                    switch (reader.GetInt32(0))
                                                    {
                                                        case 1:
                                                            label = "Dom";
                                                            break;
                                                        case 2:
                                                            label = "Lun";
                                                            break;
                                                        case 3:
                                                            label = "Mar";
                                                            break;
                                                        case 4:
                                                            label = "Mie";
                                                            break;
                                                        case 5:
                                                            label = "Jue";
                                                            break;
                                                        case 6:
                                                            label = "Vie";
                                                            break;
                                                        case 7:
                                                            label = "Sáb";
                                                            break;
                                                        default:
                                                            label = "No definido";
                                                            break;
                                                    }

                                                    result.Add(new { Label = label, count = reader.GetInt32(1) });
                                                }
                                            }
                                        }
                                        break;
                                    case "semana":
                                        result = new List<dynamic>();
                                        connection.Open();
                                        using (SqlCommand command = new SqlCommand("Select DatePart(wk,Fecha) as dia, count(*) as cantidad from Bbss group by DatePart(wk,Fecha);", connection))
                                        {
                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                while (reader.Read())
                                                {


                                                    result.Add(new { Label = reader.GetInt32(0), count = reader.GetInt32(1) });
                                                }
                                            }
                                        }
                                        break;

                                    case "mes":


                                        result = await _context.Bbss
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .GroupBy(p => p.Fecha.Month)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();

                                        break;
                                    case "proceso":
                                        result = await _context.Bbss
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Proceso)
                                        .GroupBy(p => p.Proceso.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;

                                    case "area-de-trabajo":
                                        result = await _context.Bbss
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Area)
                                        .GroupBy(p => p.Area.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;
                                    case "comportamiento-detectado":
                                        result = await _context.Bbss
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Comportamiento)
                                        .GroupBy(p => p.Comportamiento.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;
                                    case "comportamiento":
                                        result = await _context.Bbss
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.TipoComportamiento)
                                        .GroupBy(p => p.TipoComportamiento.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;
                                    case "tipo-observado":
                                        result = await _context.Bbss
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.TipoObservado)
                                        .GroupBy(p => p.TipoObservado.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;


                                    default:

                                        return StatusCode(404);


                                }
                                break;
                            case "condiciones-inseguras":
                                switch (propiedad)
                                {
                                    case "dia":

                                        connection.Open();

                                        using (SqlCommand command = new SqlCommand("Select DatePart(dw,Fecha) as dia, count(*) as cantidad from CondicionInseguras group by DatePart(dw,Fecha);", connection))
                                        {
                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                result = new List<dynamic>();
                                                while (reader.Read())
                                                {
                                                    String label;
                                                    switch (reader.GetInt32(0))
                                                    {
                                                        case 1:
                                                            label = "Dom";
                                                            break;
                                                        case 2:
                                                            label = "Lun";
                                                            break;
                                                        case 3:
                                                            label = "Mar";
                                                            break;
                                                        case 4:
                                                            label = "Mie";
                                                            break;
                                                        case 5:
                                                            label = "Jue";
                                                            break;
                                                        case 6:
                                                            label = "Vie";
                                                            break;
                                                        case 7:
                                                            label = "Sáb";
                                                            break;
                                                        default:
                                                            label = "No definido";
                                                            break;
                                                    }

                                                    result.Add(new { Label = label, count = reader.GetInt32(1) });
                                                }
                                            }
                                        }
                                        break;
                                    case "semana":
                                        result = new List<dynamic>();
                                        connection.Open();
                                        using (SqlCommand command = new SqlCommand("Select DatePart(wk,Fecha) as dia, count(*) as cantidad from CondicionInseguras group by DatePart(wk,Fecha);", connection))
                                        {
                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                while (reader.Read())
                                                {


                                                    result.Add(new { Label = reader.GetInt32(0), count = reader.GetInt32(1) });
                                                }
                                            }
                                        }
                                        break;

                                    case "mes":


                                        result = await _context.CondicionInseguras
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .GroupBy(p => p.Fecha.Month)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();

                                        break;
                                    case "proceso":
                                        result = await _context.CondicionInseguras
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Proceso)
                                        .GroupBy(p => p.Proceso.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;

                                    case "area-de-trabajo":
                                        result = await _context.CondicionInseguras
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.Area)
                                        .GroupBy(p => p.Area.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;
                            

                                    case "indicador-de-riesgo":
                                        result = await _context.CondicionInseguras
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.IndicadorRiesgo)
                                        .GroupBy(p => p.IndicadorRiesgo.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;

                                    case "factor-de-riesgo":
                                        result = await _context.CondicionInseguras
                                        .Where( p => p.Fecha >= startDate && p.Fecha <= endDate )
                                        .Include(p => p.FactorRiesgo)
                                        .GroupBy(p => p.FactorRiesgo.Nombre)
                                        .Select(g => new { Label = g.Key, Count = g.Count() })
                                        .ToListAsync();
                                        break;





                                    default:

                                        return StatusCode(404);
                                }
                                break;

                            default:
                                return StatusCode(404);

                        }
                        connection.Close();
                        dataDictionary.Add("data", result);
                        resultArray.Add(dataDictionary);

                    }



                }
                return Ok(resultArray);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
            return StatusCode(404);
        }

    }

}