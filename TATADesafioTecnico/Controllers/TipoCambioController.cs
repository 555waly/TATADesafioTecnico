using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TATADesafioTecnico.DataModel;
using TATADesafioTecnico.DataModelContext;

namespace TATADesafioTecnico.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoCambioController : ControllerBase
    {
        public TipoCambioController(DataBaseContext dbContext) {
            _dbContext = dbContext;
        }
        private readonly DataBaseContext _dbContext;


        [HttpGet]
        [Route("GetTipoCambioListIni")]
        public async Task<IActionResult> GetTipoCambioListIni()
        {
            TipoCambioDataModel tipCambio1 = new TipoCambioDataModel()
            {
                Id = Guid.NewGuid(),
                Moneda = "DOLAR",
                TipoCambio = 1
            };
            TipoCambioDataModel tipCambio2 = new TipoCambioDataModel()
            {
                Id = Guid.NewGuid(),
                Moneda = "SOL PERUANO",
                TipoCambio = 3.75
            };
            TipoCambioDataModel tipCambio3 = new TipoCambioDataModel()
            {
                Id = Guid.NewGuid(),
                Moneda = "EUR",
                TipoCambio = 0.92
            };
            TipoCambioDataModel tipCambio4 = new TipoCambioDataModel()
            {
                Id = Guid.NewGuid(),
                Moneda = "PESO MEXICANO",
                TipoCambio = 18.16    
            };
            TipoCambioDataModel tipCambio5 = new TipoCambioDataModel()
            {
                Id = Guid.NewGuid(),
                Moneda = "CHELIN",
                TipoCambio =133.60
            };

            _dbContext.TipoCambiosActual.Add(tipCambio1);
            _dbContext.TipoCambiosActual.Add(tipCambio2);
            _dbContext.TipoCambiosActual.Add(tipCambio3);
            _dbContext.TipoCambiosActual.Add(tipCambio4);
            _dbContext.TipoCambiosActual.Add(tipCambio5);
            _dbContext.SaveChanges();

            return Ok(_dbContext.TipoCambiosActual.ToList());
        }

        [HttpGet]
        [Route("GetTipoCambioList")]
        public async Task<IActionResult> GetTipoCambioList()
        {
            return Ok(_dbContext.TipoCambiosActual.ToList());
        }


        [HttpPost]
        [Route("PostAddTipoCambio")]
        public async Task<IActionResult> PostAddTipoCambio(TipoCambioDataModel obj)
        {
            TipoCambioDataModel tipoCambio = new TipoCambioDataModel() { 
               Id=Guid.NewGuid(),
                    Moneda= obj.Moneda,
                    TipoCambio=obj.TipoCambio
            };
            _dbContext.TipoCambiosActual.Add(tipoCambio);
            _dbContext.SaveChanges();
            return Ok(tipoCambio);
        }

        [HttpPost]
        [Route("PostUpdTipoCambio")]
        public async Task<IActionResult> PostUpdTipoCambio(TipoCambioDataModel obj)
        {
            TipoCambioDataModel TipoCambioUpd = 
                _dbContext.TipoCambiosActual.Where(x=>x.Id==obj.Id).Single();

            TipoCambioUpd.Moneda = obj.Moneda;
            TipoCambioUpd.TipoCambio = obj.TipoCambio;
            _dbContext.TipoCambiosActual.Update(TipoCambioUpd);
            _dbContext.SaveChanges();
            return Ok(TipoCambioUpd);
        }

        ///////////////////////
        [HttpGet]
        [Route("GetTipoCambio")]
        public async Task<IActionResult> GetTipoCambio(Double monto, string monedaOrigen, string monedaDestino)
        {
            List<TipoCambioDataModel> TipoCambioLst = _dbContext.TipoCambiosActual.ToList();
            double tipCambOrigen = TipoCambioLst.Where(x => x.Moneda == monedaOrigen).Select(x => x.TipoCambio).FirstOrDefault();
            double tipCambDestino = TipoCambioLst.Where(x => x.Moneda == monedaDestino).Select(x => x.TipoCambio).FirstOrDefault();

            double Conversion = (monto / tipCambOrigen) * tipCambDestino;

            return Ok(new
            {
                Monto = monto,
                MontoTipoCambio = Conversion,
                MonedaOrigen = monedaOrigen,
                MonedaDestino = monedaDestino,
                TipoCambio= tipCambDestino
            });


        }

    }
}
