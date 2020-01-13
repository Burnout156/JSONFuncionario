using JSONEmpresa.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Mvc;

namespace JSONEmpresa.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            /*Funcionario funcionario = new Funcionario()
            { nome = "Funcionário1", idade = 30, salario = 120000 };
            string jsondata = new JavaScriptSerializer().Serialize(funcionario);
            string path = Server.MapPath("~/App_Data/");*/
            return View();
        }

        // GET: Funcionario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public JsonResult PegarDados()
        {
            string path = Server.MapPath("~/App_Data/");
            string file = System.IO.File.ReadAllText(path + "funcionarios.json");
            List<Funcionario> funcionariosAntigos = JsonConvert.DeserializeObject<List<Funcionario>>(file);
            return Json(funcionariosAntigos, JsonRequestBehavior.AllowGet);
        }

        // GET: Funcionario/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionario/Create
        [HttpPost]
        public ActionResult Create(Funcionario fun)
        {
            try
            {
                string path = Server.MapPath("~/App_Data/");

                if (System.IO.File.Exists(path + "funcionarios.json"))
                {
                    string file = System.IO.File.ReadAllText(path + "funcionarios.json"); //lê todos os dados em texto do json
                    List<Funcionario> funcionariosAntigos = JsonConvert.DeserializeObject<List<Funcionario>>(file); //converte em objetos do tipo funcionario
                    List<Funcionario> funcionariosAtt = new List<Funcionario>();
                    funcionariosAtt.AddRange(funcionariosAntigos); //para adicionar o tamanho de acordo com os funcionarios antigos
                    funcionariosAtt.Add(fun); //para adicionar o funcionario novo
                    string jsondata2 = JsonConvert.SerializeObject(funcionariosAtt, Formatting.Indented); //serializar os funcionarios atualizados em texto
                    System.IO.File.WriteAllText(path + "funcionarios.json", jsondata2);// escrevendo o texto serializado no json
                    System.Console.Write("Fun" + fun);
                    System.Console.Write("Funcionarios att" + funcionariosAtt);
                    System.Console.Write("JsonData2" + jsondata2);
                }

                else
                {
                    List<Funcionario> funcionariosAtt = new List<Funcionario>();
                    
                    funcionariosAtt.Add(fun);
                    string jsondata = JsonConvert.SerializeObject(funcionariosAtt, Formatting.Indented);
                    System.IO.File.WriteAllText(path + "funcionarios.json", jsondata);
                    System.Console.Write("Fun" + fun);
                    System.Console.Write("Funcionarios att" + funcionariosAtt);
                    System.Console.Write("JsonData" + jsondata);
                }

                TempData["msg"] = "Json file Generated! check this in your App_Data folder";

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public void GravarJson(Funcionario f)
        {
            //string jsondata = JsonConvert.SerializeObject(f);
            string file = Server.MapPath("~/App_Data/output.json");
            string path = Server.MapPath("~/App_Data/");
            string json = System.IO.File.ReadAllText(file);
            //var meuObj = JObject.Parse(json);
            //string funcionarios = new JavaScriptSerializer().Deserialize<string>(file);
            //funcionarios = funcionarios + f.ToString();
            //string jsonnew = JsonConvert.Serialize(funcionarios);
            //System.IO.File.AppendAllText(path + "output.json", jsonnew);
            System.IO.File.WriteAllText(path + "output.json", f.ToString());
            TempData["msg"] = "Json file Generated! check this in your App_Data folder";

        }

        // GET: Funcionario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        public byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        // POST: Funcionario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Funcionario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Funcionario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
