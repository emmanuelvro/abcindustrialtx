﻿using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace abcindustrialtx.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CalibresController : Controller
    {
        private ICatCalibresBLL _catCalibre;
        private readonly IMapper _mapper = null;
        public CalibresController(ICatCalibresBLL catCalibre, IMapper mapper)
        {
            _catCalibre = catCalibre;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCalibres()
        {
            return Ok(_catCalibre.GetCalibres());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_catCalibre.GetCalibreById(id));
        }

        [HttpPost]
        public IActionResult InsertCalibre(CatCalibre calibres)
        {
            //var calibre = _mapper.Map<CatCalibre>(calibres);
            calibres.FechaModificacion = DateTime.Now;
            calibres.Activo = 1;
            return Ok(_catCalibre.Insert(calibres));
        }

        [HttpDelete("{id}")]
        public ActionResult<CatCalibre> Delete(int id)
        {
            CatCalibre existeCalibre = _catCalibre.GetCalibreById(id);

            if (existeCalibre == null)
            {
                return NotFound();
            }

            _catCalibre.Delete(existeCalibre);

            return existeCalibre;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCalibre(int id, CatCalibre entidad)
        {
            if (id != entidad.IdCalibre)
            {
                return BadRequest();
            }

            try
            {
                _catCalibre.Update(entidad, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalibreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool CalibreExists(int id)
        {
            return _catCalibre.GetCalibres().Any(e => e.IdCalibre == id);
        }
   
    }
}
