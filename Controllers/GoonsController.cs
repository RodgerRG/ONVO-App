using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ONVO_App.GoonGenerator;
using ONVO_App.Models;
using ONVO_App.Database;
using ONVO_App.Structs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
namespace ONVO_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoonsController : ControllerBase
    {
        private static int number, level, minStat, maxStat, minHP, maxHP, minMaxRP, maxMaxRP, minStartRP, maxStartRP, minRPMod, maxRPMod;
        private DatabaseController dbController;
        GoonGenerator.GoonGenerator generator = new GoonGenerator.GoonGenerator();

        [HttpGet]
        public IActionResult ping() {
            return Ok();
        }

        [HttpGet("MakeGoons")]
        public GoonModel[] MakeGoons() {
            Goon[] goons = generator.generateGoons(number, level, minStat, maxStat, 
                minHP, maxHP, minStartRP, maxStartRP, minMaxRP, maxMaxRP, 
                minRPMod, maxRPMod);
            
            GoonModel[] models = new GoonModel[goons.Length];

            dbController = new DatabaseController();

            for(int i = 0; i < models.Length; i++) {
                models[i] = (GoonModel) goons[i];
                dbController.sendGoon(models[i]);
            }

            return models;
        }

        [HttpGet("GetGoons")]
        public GoonModel[] GetGoons() {
            dbController = new DatabaseController();
            GoonModel[] goons = dbController.getGoons().Result.ToArray();

            return goons;
        }

        [HttpPost("SetNumberGoons/{number}")]
        public IActionResult SetNumberGoons(int number) {
            Thread.Sleep(2000);
            GoonsController.number = number;

            return Accepted("", string.Format("Goon Level is: {0}", level));
        }

        [HttpPost("SetGoonLevel/{number}")]
        public IActionResult SetGoonLevel(int number) {
            GoonsController.level = number;

            return Accepted("", string.Format("Number of Goons is: {0}", GoonsController.number));
        }

        [HttpPost("SetGoonMinStat/{number}")]
        public IActionResult SetGoonMinStat(int number) {
            GoonsController.minStat = number;

            return Accepted();

        }

        [HttpPost("SetGoonMaxStat/{number}")]
        public IActionResult SetGoonMaxStat(int number) {
            GoonsController.maxStat = number;

            return Accepted();
        }

        [HttpPost("SetGoonMinHP/{number}")]
        public IActionResult SetGoonMinHP( int number) {
            GoonsController.minHP = number;

            return Accepted();
        }

        [HttpPost("SetGoonMaxHP/{number}")]
        public IActionResult SetGoonMaxHP(int number) {
            GoonsController.maxHP = number;

            return Accepted();

        }

        [HttpPost("SetGoonMinStartRP/{number}")]
        public IActionResult SetGoonMinStartRP(int number) {
            GoonsController.minStartRP = number;

            return Accepted();
        }

        [HttpPost("SetGoonMaxStartRP/{number}")]
        public IActionResult SetGoonMaxStartRP(int number) {
            GoonsController.maxStartRP = number;

            return Accepted();

        }

        [HttpPost("SetGoonMinRPMod/{number}")]
        public IActionResult SetGoonMinRPMod( int number) {
            GoonsController.minRPMod = number;

            return Accepted();

        }

        [HttpPost("SetGoonMaxRPMod/{number}")]
        public IActionResult SetGoonMaxRPMod(int number) {
            GoonsController.maxRPMod = number;

            return Accepted();

        }

        [HttpPost("SetGoonMinMaxRP/{number}")]
        public IActionResult SetGoonMinMaxRP( int number) {
            GoonsController.minMaxRP = number;

            return Accepted();
        }

        [HttpPost("SetGoonMaxMaxRP/{number}")]
        public IActionResult SetGoonMaxMaxRP(int number) {
            GoonsController.maxMaxRP = number;

            return Accepted();
        }
    }
}