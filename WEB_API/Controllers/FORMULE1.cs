using LIB_C_BASE;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WEB_API.Controllers
{

    [ApiController]
    [Route("/api")]
    public class FORMULE1 : ControllerBase
    {

        C_BASE _Base;


        public FORMULE1(C_BASE P_Base)
        {
            _Base = P_Base;
        }

        [HttpGet("Get_All_Driver", Name = "GetAllDriver")]
        public List<C_DRIVER> Get_All_Driver() => (List<C_DRIVER>)_Base.Get_All_Driver();

        [HttpGet("Get_All_Constructeur", Name = "GetAllConstructeur")]
        public List<C_CONSTRUCTEUR> Get_All_Constructeur() => (List<C_CONSTRUCTEUR>)_Base.Get_All_Constructeur();

        [HttpGet("Get_Driver_By_Constructeur", Name = "GetDriverByConstructeur")]
        public List<C_DRIVER> Get_Driver_By_Constructeur(int P_Id) => (List<C_DRIVER>)_Base.Get_Driver_By_Constructeur(P_Id);

        [HttpGet("Get_Point_By_Constructeur", Name = "GetPointByConstructeur")]
        public List<C_CHAMPIONNAT_CONSTRUCTEUR> Get_Point_By_Constructeur(int P_IdConstructeur) => (List<C_CHAMPIONNAT_CONSTRUCTEUR>)_Base.Get_Point_By_Constructeur(P_IdConstructeur);

        [HttpGet("Get_Point_By_Pilote", Name = "GetPointByPilote")]
        public List<C_CHAMPIONNAT_PILOTE> Get_Point_By_Pilote(int P_IdPilote) => (List<C_CHAMPIONNAT_PILOTE>)_Base.Get_Point_By_Pilote(P_IdPilote);

        [HttpPut("Add_Driver",Name = "AddDriver")]
        public ActionResult<C_DRIVER> Add_Driver([FromBody] C_DRIVER P_Driver)
        {
            var Nouveau_Driver = _Base.Add_Driver(P_Driver.Id_Constructeur,P_Driver.Nom,P_Driver.Prenom);

            if (Nouveau_Driver != false) return Ok(Nouveau_Driver);
            else return NoContent();
        }

        [HttpPut("Add_Constructeur", Name ="AddConstructeur")]
        public ActionResult<C_CONSTRUCTEUR> Add_Constructeur(string P_Nom)
        {
            var Nouveau_Constructeur = _Base.Add_Constructeur(P_Nom);

            if (Nouveau_Constructeur != false) return Ok(Nouveau_Constructeur);
            else return NoContent();
        }

        [HttpPut("Update_Driver",Name ="UpdateDriver")]
        public ActionResult Update_Driver([FromBody] C_DRIVER P_Driver)
        {
            var Update_Ok = _Base.Update_Driver(P_Driver.Id, P_Driver.Id_Constructeur, P_Driver.Nom, P_Driver.Prenom);

            if (Update_Ok) return Ok();
            else return NotFound(Update_Ok);
        }

        [HttpPut("Update_Constructeur", Name = "UpdateConstructeur")]
        public ActionResult Update_Constructeur([FromBody] C_CONSTRUCTEUR P_Constructeur)
        {
            var Update_Ok = _Base.Update_Constructeur(P_Constructeur.Id,P_Constructeur.Nom);

            if (Update_Ok) return Ok();
            else return NotFound(Update_Ok);
        }

        [HttpDelete("Delete_Driver",Name = "DeleteDriver")]
        public ActionResult Delete_Driver(int P_Id)
        {
            var Delete_Ok = _Base.Delete_Driver(P_Id);

            if (Delete_Ok) return Ok();
            else return NotFound(Delete_Ok);
        }

        [HttpDelete("Delete_Constructeur", Name = "DeleteConstructeur")]
        public ActionResult Delete_Constructeur(int P_Id)
        {
            var Delete_Ok = _Base.Delete_Constructeur(P_Id);

            if (Delete_Ok) return Ok();
            else return NotFound(Delete_Ok);
        }
    }
}
