﻿using Microsoft.AspNetCore.Mvc;
using KnockKnockRest.Models;
using KnockKnockRest.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KnockKnockRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private StudentsRepository _repository = new StudentsRepository();

        public StudentsController(StudentsRepository repository)
        {
            _repository = repository;   
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            List<Student> result = _repository.GetAll();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<StudentsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            Student? foundStudent = _repository.GetByID(id);
            if (foundStudent == null)
            {
                return NotFound();
            }
            return Ok(foundStudent);
        }

        // POST api/<StudentsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student newStudent)
        {
            try
            {
                Student createdStudent = _repository.Add(newStudent);
                return Created("api/Students/" + createdStudent.Id, createdStudent);
            }
            catch (Exception ex) when (ex is ArgumentNullException ||
                                       ex is ArgumentOutOfRangeException ||
                                       ex is ArgumentException)
            {
                return BadRequest(ex.InnerException);
            }
        }

        // PUT api/<StudentsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Student> Put(int id, [FromBody] Student updates)
        {
            try
            {
                Student? updatedStudent = _repository.Update(id, updates);
                if (updatedStudent == null)
                {
                    return NotFound();
                }
                return Ok(updatedStudent);
            }
            catch (Exception ex) when (ex is ArgumentNullException ||
                                       ex is ArgumentOutOfRangeException ||
                                       ex is ArgumentException)
            {
                return BadRequest(ex.InnerException);
            }
        }

        // DELETE api/<StudentsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Student> Delete(int id)
        {
            Student? deletedStudent = _repository.Delete(id);
            if (deletedStudent == null)
            {
                return NotFound();
            }
            return Ok(deletedStudent);
        }
    }
}
