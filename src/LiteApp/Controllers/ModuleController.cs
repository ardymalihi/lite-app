using Microsoft.AspNetCore.Mvc;
using LiteApp.Services;
using LiteApp.ViewModels;
using Newtonsoft.Json;
using LiteApp.Common;
using Newtonsoft.Json.Linq;
using LiteApp.Models;

namespace LiteApp.Controllers
{
    public class ModuleController : BaseController
    {

        public ModuleController(IAppService appService) : base(appService) { }
        
        public IActionResult Settings(string id)
        {
            var module = this.AppService.GetModule(id);

            var settingsViewModel = new SettingsViewModel
            {
                JsonData = JsonConvert.SerializeObject(module, Formatting.Indented, new JsonModuleConverter()),
                JsonSchema = GetModuleSchema(),
                SaveEndpoint = "/module/save/" + id
            };

            return View("Settings", settingsViewModel);
        }

        [HttpPost]
        public IActionResult Save(string id, [FromBody]JObject request)
        {
            var module = this.AppService.GetModule(id);

            module = JsonConvert.DeserializeObject(request.ToString(), module.GetType(), new JsonModuleConverter()) as dynamic;

            var app = this.AppService.ApplySettings(this.AppService.App, module);

            this.AppService.Save(app);

            return Ok();
        }

        private string GetModuleSchema()
        {
            return @"{
  'Title': 'Module Settings',
  'properties': {
	'Id': {
	  'type': 'string',
	  'default': null,
	  'readonly': true
	},
	'Styles': {
	  'format': 'tabs',
	  'required': true,
	  'type': 'array',
	  'items': {
		'headerTemplate': 'Style {{ i1 }}',
		'type': 'object',
		'properties': {
		  'Path': {
			'required': true,
			'type': 'string'
		  }
		}
	  }
	},
	'Scripts': {
	  'format': 'tabs',
	  'required': true,
	  'type': 'array',
	  'items': {
		'headerTemplate': 'Script {{ i1 }}',
		'type': 'object',
		'properties': {
		  'Path': {
			'required': true,
			'type': 'string'
		  }
		}
	  }
	}
  },
  'oneOf': [
	{
	  'title': 'Html Module',
	  'type': 'object',
	  'properties': {
		'Type': {
		  'type': 'string',
		  'default': 'HtmlModule',
		  'readonly': true
		},
		'Content': {
		  'format': 'html',
		  'options': {
			'wysiwyg': false
		  },
		  'required': true,
		  'type': 'string'
		}
	  }
	},
	{
	  'title': 'Contact Module',
	  'type': 'object',
	  'properties': {
		'Type': {
		  'type': 'string',
		  'default': 'ContactModule',
		  'readonly': true
		},
		'Email': {
		  'required': true,
		  'type': 'string'
		},
		'Phone': {
		  'required': true,
		  'type': 'string'
		},
		'Address': {
		  'required': true,
		  'type': 'string'
		}
	  }
	}
  ]
}";
        }
    }
}
