using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bbs.Models;
using bbs.DTOs;
using System.Collections.Generic;
using System;

namespace bbs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormulariosController : Controller
    {
        // SelectId 1: Actividades
        // SelectId 2: Areas
        // SelectId 3: Casualidades
        // SelectId 4: Causas Basicas
        // SelectId 5: Causas inmediatas
        // SelectId 6: Clasificaciones
        // SelectId 7: Comportamientos
        // SelectId 8: Efectos
        // SelectId 9: Factor Riesgo
        // SelectId 10: Generos
        // SelectId 11: Indicador Riesgos
        // SelectId 12: Jornadas
        // SelectId 13: Observados
        // SelectId 14: Parte Cuerpos   
        // SelectId 15: Procesos
        // SelectId 16: Riesgos
        // SelectId 17: Tipo comportamiento
        // SelectId 18: Tipo Observado
        // SelectId 19: Turnos
        private readonly SBBSContext _context;

        public FormulariosController(SBBSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSelectOptions()
        {


            List<SelectDto> selectDtos = new List<SelectDto>();
            var Actividades = await _context.Actividades.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, Actividades, 1);

            var Areas = await _context.Areas.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, Areas, 2);

            var Casualidades = await _context.Casualidades.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, Casualidades, 3);

            var CausaBasicas = await _context.CausaBasicas.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, CausaBasicas, 4);

            var CausaInmediatas = await _context.CausaInmediatas.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, CausaInmediatas, 5);

            var Clasificaciones = await _context.Clasificaciones.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, Clasificaciones, 6);

            var Comportamientos = await _context.Comportamientos.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, Comportamientos, 7);

            var Efectos = await _context.Efectos.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, Efectos, 8);

            var FactorRiesgos = await _context.FactorRiesgos.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, FactorRiesgos, 9);

            var Generos = await _context.Generos.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, Generos, 10);


            var IndicadorRiesgos = await _context.IndicadorRiesgos.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, IndicadorRiesgos, 11);

            var Jornadas = await _context.Jornadas.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, Jornadas, 12);

            var Observados = await _context.Observados.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, Observados, 13);

            var ParteCuerpos = await _context.ParteCuerpos.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, ParteCuerpos, 14);

            var Procesos = await _context.Procesos.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, Procesos, 15);

            var Riesgos = await _context.Riesgos.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, Riesgos, 16);

            var TipoComportamientos = await _context.TipoComportamientos.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, TipoComportamientos, 17);

            var TipoObservados = await _context.TipoObservados.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, TipoObservados, 18);

            var Turnos = await _context.Turnos.ToListAsync();
            FormulariosShared.addSelectToList(selectDtos, Turnos, 19);
            return Ok(selectDtos);
        }

        [HttpPost("new")]
        public async Task<IActionResult> InsertSelectOption(SelectDto selectDto)
        {
            bool notFound = false;
            dynamic selectObj = null;
            switch (selectDto.SelectId)
            {
                case 1:
                    selectObj = new Actividad
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.Actividades.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 2:
                    selectObj = new Area
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.Areas.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 3:
                    selectObj = new Casualidad
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.Casualidades.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 4:
                    selectObj = new CausaBasica
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.CausaBasicas.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 5:
                    selectObj = new CausaInmediata
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.CausaInmediatas.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 6:
                    selectObj = new Clasificacion
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.Clasificaciones.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 7:
                    selectObj = new Comportamiento
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.Comportamientos.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 8:
                    selectObj = new Efecto
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.Efectos.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 9:
                    selectObj = new FactorRiesgo
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.FactorRiesgos.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 10:
                    selectObj = new Genero
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.Generos.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 11:
                    selectObj = new IndicadorRiesgo
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.IndicadorRiesgos.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 12:
                    selectObj = new Jornada
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.Jornadas.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 13:
                    selectObj = new Observado
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.Observados.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 14:
                    selectObj = new ParteCuerpo
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.ParteCuerpos.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 15:
                    selectObj = new Proceso
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.Procesos.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 16:
                    selectObj = new Riesgo
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.Riesgos.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 17:
                    selectObj = new TipoComportamiento
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.TipoComportamientos.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 18:
                    selectObj = new TipoObservado
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.TipoObservados.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;
                case 19:
                    selectObj = new Turno
                    {
                        Nombre = selectDto.Nombre
                    };
                    await _context.Turnos.AddAsync(selectObj);
                    await _context.SaveChangesAsync();
                    break;


                default:
                    notFound = true;
                    break;
            }
            if (notFound)
            {
                return StatusCode(400);
            }
            Bitacora bitacora = new Bitacora
                {
                    Fecha = DateTime.Now,
                    Usuario = "Usuario",
                    DescripcionBitacora = $"Creó nueva opción de formulario {selectObj.Nombre}"
                };
                await _context.Bitacora.AddAsync(bitacora);
            return Ok(selectObj);

        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateSelectOption(SelectDto selectDto)
        {
            bool notFound = false;
            var selectId = selectDto.SelectId;
            var optionId = selectDto.OptionId;
            var nombre = selectDto.Nombre;
            dynamic selectObj = null;
            switch (selectId)
            {
                case 1:
                    selectObj = await _context.Actividades.FirstOrDefaultAsync( selectDto => selectDto.Id == optionId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.Actividades.Update(selectObj);
                    }
                    break;
                case 2:
                    selectObj = await _context.Areas.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.Areas.Update(selectObj);
                    }
                    break;
                case 3:
                    selectObj = await _context.Casualidades.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.Casualidades.Update(selectObj);
                    }
                    break;
                case 4:
                    selectObj = await _context.CausaBasicas.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.CausaBasicas.Update(selectObj);
                    }
                    break;
                case 5:
                    selectObj = await _context.CausaInmediatas.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.CausaInmediatas.Update(selectObj);
                    }
                    break;
                case 6:
                    selectObj = await _context.Clasificaciones.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.Clasificaciones.Update(selectObj);
                    }
                    break;
                case 7:
                    selectObj = await _context.Comportamientos.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.Comportamientos.Update(selectObj);
                    }
                    break;
                case 8:
                    selectObj = await _context.Efectos.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.Efectos.Update(selectObj);
                    }
                    break;
                case 9:
                    selectObj = await _context.FactorRiesgos.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.FactorRiesgos.Update(selectObj);
                    }
                    break;
                case 10:
                    selectObj = await _context.Generos.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.Generos.Update(selectObj);
                    }
                    break;
                case 11:
                    selectObj = await _context.IndicadorRiesgos.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.IndicadorRiesgos.Update(selectObj);
                    }
                    break;
                case 12:
                    selectObj = await _context.Jornadas.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.Jornadas.Update(selectObj);
                    }
                    break;
                case 13:
                    selectObj = await _context.Observados.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.Observados.Update(selectObj);
                    }
                    break;
                case 14:
                    selectObj = await _context.ParteCuerpos.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.ParteCuerpos.Update(selectObj);
                    }
                    break;
                case 15:
                    selectObj = await _context.Procesos.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.Procesos.Update(selectObj);
                    }
                    break;
                case 16:
                    selectObj = await _context.Riesgos.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.Riesgos.Update(selectObj);
                    }
                    break;
                case 17:
                    selectObj = await _context.TipoComportamientos.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.TipoComportamientos.Update(selectObj);
                    }
                    break;
                case 18:
                    selectObj = await _context.TipoObservados.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.TipoObservados.Update(selectObj);
                    }
                    break;
                case 19:
                    selectObj = await _context.Turnos.FirstOrDefaultAsync( selectDto => selectDto.Id == selectId);
                    if (selectObj != null){
                        selectObj.Nombre = nombre;
                        _context.Turnos.Update(selectObj);
                    }
                    break;


                default:
                    notFound = true;
                    break;
            }
            if (notFound)
            {
                return StatusCode(400);
            }
            else
            {
                Bitacora bitacora = new Bitacora
                {
                    Fecha = DateTime.Now,
                    Usuario = "Usuario",
                    DescripcionBitacora = $"Actualizó opcion de formulario {selectObj.Nombre}"
                };
                await _context.Bitacora.AddAsync(bitacora);
                await _context.SaveChangesAsync();
                return StatusCode(201);

            }

        }

        [HttpDelete]

        public async Task<IActionResult> DeleteOption(int optionId, int selectId)
        {
            bool notFound = false;
            switch (selectId)
            {
                case 1:
                    Actividad actividad = new Actividad
                    {
                        Id = optionId
                    };
                    _context.Actividades.Remove(actividad);
                    break;
                case 2:
                    Area Area = new Area
                    {

                        Id = optionId
                    };
                    _context.Areas.Remove(Area);
                    break;
                case 3:
                    Casualidad Casualidad = new Casualidad
                    {

                        Id = optionId
                    };
                    _context.Casualidades.Remove(Casualidad);
                    break;
                case 4:
                    CausaBasica CausaBasica = new CausaBasica
                    {

                        Id = optionId
                    };
                    _context.CausaBasicas.Remove(CausaBasica);
                    break;
                case 5:
                    CausaInmediata CausaInmediata = new CausaInmediata
                    {

                        Id = optionId
                    };
                    _context.CausaInmediatas.Remove(CausaInmediata);
                    break;
                case 6:
                    Clasificacion Clasificacion = new Clasificacion
                    {

                        Id = optionId
                    };
                    _context.Clasificaciones.Remove(Clasificacion);
                    break;
                case 7:
                    Comportamiento Comportamiento = new Comportamiento
                    {

                        Id = optionId
                    };
                    _context.Comportamientos.Remove(Comportamiento);
                    break;
                case 8:
                    Efecto Efecto = new Efecto
                    {

                        Id = optionId
                    };
                    _context.Efectos.Remove(Efecto);
                    break;
                case 9:
                    FactorRiesgo FactorRiesgo = new FactorRiesgo
                    {

                        Id = optionId
                    };
                    _context.FactorRiesgos.Remove(FactorRiesgo);
                    break;
                case 10:
                    Genero Genero = new Genero
                    {

                        Id = optionId
                    };
                    _context.Generos.Remove(Genero);
                    break;
                case 11:
                    IndicadorRiesgo IndicadorRiesgo = new IndicadorRiesgo
                    {

                        Id = optionId
                    };
                    _context.IndicadorRiesgos.Remove(IndicadorRiesgo);
                    break;
                case 12:
                    Jornada Jornada = new Jornada
                    {

                        Id = optionId
                    };
                    _context.Jornadas.Remove(Jornada);
                    break;
                case 13:
                    Observado Observado = new Observado
                    {

                        Id = optionId
                    };
                    _context.Observados.Remove(Observado);
                    break;
                case 14:
                    ParteCuerpo ParteCuerpo = new ParteCuerpo
                    {

                        Id = optionId
                    };
                    _context.ParteCuerpos.Remove(ParteCuerpo);
                    break;
                case 15:
                    Proceso Proceso = new Proceso
                    {

                        Id = optionId
                    };
                    _context.Procesos.Remove(Proceso);
                    break;
                case 16:
                    Riesgo Riesgo = new Riesgo
                    {

                        Id = optionId
                    };
                    _context.Riesgos.Remove(Riesgo);
                    break;
                case 17:
                    TipoComportamiento TipoComportamiento = new TipoComportamiento
                    {

                        Id = optionId
                    };
                    _context.TipoComportamientos.Remove(TipoComportamiento);
                    break;
                case 18:
                    TipoObservado TipoObservado = new TipoObservado
                    {

                        Id = optionId
                    };
                    _context.TipoObservados.Remove(TipoObservado);
                    break;
                case 19:
                    Turno Turno = new Turno
                    {

                        Id = optionId
                    };
                    _context.Turnos.Remove(Turno);
                    break;


                default:
                    notFound = true;
                    break;
            }
            if (notFound)
            {
                return StatusCode(400);
            }
            else
            {
                
                await _context.SaveChangesAsync();
                return StatusCode(202);

            }
        }
    }


    public class FormulariosShared
    {
        public static void addSelectToList(List<SelectDto> selectDtos, dynamic selects, int SelectId)
        {
            foreach (var select in selects)
            {
                SelectDto selectDto = new SelectDto { Nombre = select.Nombre, OptionId = select.Id, SelectId = SelectId };
                selectDtos.Add(selectDto);
            }
        }


    }

}