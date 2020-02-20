using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ONVO_App.GoonGenerator;

namespace ONVO_App.Controllers
{
    public class GoonsController : ApiController
    {
        private int number, level, minStat, maxStat, minHP, maxHP, minMaxRP, maxMaxRP, minStartRP, maxStartRP, minRPMod, maxRPMod;
        GoonGenerator.GoonGenerator generator = new GoonGenerator.GoonGenerator();

        [HttpGet]
        public IHttpActionResult MakeGoons() {
            Goon[] goons = generator.generateGoons(number, level, minStat, maxStat, 
                minHP, maxHP, minStartRP, maxStartRP, minMaxRP, maxMaxRP, 
                minRPMod, maxRPMod);

            return Ok(goons);
        }

        [HttpPost]
        public IHttpActionResult SetNumberGoons(int number) {
            this.number = number;

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult SetGoonLevel(int number) {
            this.level = number;

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult SetGoonMinStat(int number) {
            this.minStat = number;

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult SetGoonMaxStat(int number) {
            this.maxStat = number;

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult SetGoonMinHP(int number) {
            this.minHP = number;

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult SetGoonMaxHP(int number) {
            this.maxHP = number;

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult SetGoonMinStartRP(int number) {
            this.minStartRP = number;

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult SetGoonMaxStartRP(int number) {
            this.maxStartRP = number;

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult SetGoonMinRPMod(int number) {
            this.minRPMod = number;

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult SetGoonMaxRPMod(int number) {
            this.maxRPMod = number;

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult SetGoonMinMaxRP(int number) {
            this.minMaxRP = number;

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult SetGoonMaxMaxRP(int number) {
            this.maxMaxRP = number;

            return Ok();
        }
    }
}