using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebServiceConsole.Models;

namespace WebServiceConsole.Controller
{
    [Authorize]
    public class TodoTasksController : ApiController
    {
        public MyContext db = new MyContext();

        public IEnumerable<TodoTask> Get()
        {
            var user = db.Users.Find(Int32.Parse(((ClaimsIdentity)this.User.Identity).Claims.First().Value));
            return db.TodoTasks.Where(u => u.User.Id == user.Id).OrderBy(u => u.Title).ToList<TodoTask>();
        }

        public IHttpActionResult Get(int id)
        {
            var user = db.Users.Find(Int32.Parse(((ClaimsIdentity)this.User.Identity).Claims.First().Value));

            var todoTask = db.TodoTasks.Find(id);

            if (todoTask == null || todoTask.User == null || todoTask.User.Id != user.Id)
            {
                return NotFound();
            }
            else
            {
                return Ok(todoTask);
            }
        }

        public IHttpActionResult Post(TodoTask todoTask)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }

            var user = db.Users.Find(Int32.Parse(((ClaimsIdentity)this.User.Identity).Claims.First().Value));
            todoTask.User = user;
            db.TodoTasks.Add(todoTask);
            db.SaveChanges();
            return Ok(todoTask);
        }

        public bool Put(int id, TodoTask todoTask)
        {
            var user = db.Users.Find(Int32.Parse(((ClaimsIdentity)this.User.Identity).Claims.First().Value));
            var todo = db.TodoTasks.Find(todoTask.Id);

            if (todo == null || todo.User == null || todo.User.Id != user.Id)
            {
                return false;
            }
            else
            {
                todo.IsTaskOver = todoTask.IsTaskOver;
                todo.Title = todoTask.Title;
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
                return true;    
            }
        }

        public bool Delete(int id)
        {
            var user = db.Users.Find(Int32.Parse(((ClaimsIdentity)this.User.Identity).Claims.First().Value));
            TodoTask todoTask = db.TodoTasks.Find(id);

            if (todoTask == null || todoTask.User == null || todoTask.User.Id != user.Id)
            {
                return false;
            }
            else
            {
                db.TodoTasks.Remove(todoTask);
                db.SaveChanges();
                return true;
            }
        }
    }
}
