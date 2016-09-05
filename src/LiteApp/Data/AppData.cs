using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.IO;

namespace LiteApp.Data
{
    public class AppData : IAppData
    {
        private IHostingEnvironment _env;
        private readonly string FILE_NAME = "appData.json";

        public AppData(IHostingEnvironment env)
        {
            _env = env;
        }
        
        public App Load()
        {
            App app = new App();

            if (!Exists())
            {
                app = Seed();

                Save(app);

                return app;
                
            }
            else
            {
                new ConfigurationBuilder()
                        .SetBasePath(_env.ContentRootPath)
                        .AddJsonFile(FILE_NAME, true)
                        .Build()
                        .Bind(app);

                return app;
            }
        }

        public void Save(App app)
        {
            var appDataFile = File.Create(Path.Combine(_env.ContentRootPath, FILE_NAME));
            var appDataWriter = new StreamWriter(appDataFile);
            appDataWriter.WriteLine(JsonConvert.SerializeObject(app, Formatting.Indented));
            appDataWriter.Dispose();
        }

        private bool Exists()
        {
            return File.Exists(Path.Combine(_env.ContentRootPath, FILE_NAME));
        }

        private App Seed()
        {
            App app = new App {
                Title = "Test App",
                Menus = new List<MenuItem> {
                    new MenuItem {
                        Title = "Home",
                        Route = "/"
                    },
                    new MenuItem {
                        Title = "Contact Us",
                        Route = "/contact"
                    },
                },
                HeaderHtml = @"
<div id='myCarousel' class='carousel slide' data-ride='carousel' data-interval='6000'>
<ol class='carousel-indicators'>
	<li data-target='#myCarousel' data-slide-to='0' class='active'></li>
	<li data-target='#myCarousel' data-slide-to='1'></li>
	<li data-target='#myCarousel' data-slide-to='2'></li>
	<li data-target='#myCarousel' data-slide-to='3'></li>
</ol>
<div class='carousel-inner' role='listbox'>
	<div class='item active'>
		<img src='/images/banner1.svg' alt='ASP.NET' class='img-responsive' />
		<div class='carousel-caption' role='option'>
			<p>
				Learn how to build ASP.NET apps that can run anywhere.
				<a class='btn btn-default' href='http://go.microsoft.com/fwlink/?LinkID=525028&clcid=0x409'>
					Learn More
				</a>
			</p>
		</div>
	</div>
	<div class='item'>
		<img src='/images/banner2.svg' alt='Visual Studio' class='img-responsive' />
		<div class='carousel-caption' role='option'>
			<p>
				There are powerful new features in Visual Studio for building modern web apps.
				<a class='btn btn-default' href='http://go.microsoft.com/fwlink/?LinkID=525030&clcid=0x409'>
					Learn More
				</a>
			</p>
		</div>
	</div>
	<div class='item'>
		<img src='/images/banner3.svg' alt='Package Management' class='img-responsive' />
		<div class='carousel-caption' role='option'>
			<p>
				Bring in libraries from NuGet, Bower, and npm, and automate tasks using Grunt or Gulp.
				<a class='btn btn-default' href='http://go.microsoft.com/fwlink/?LinkID=525029&clcid=0x409'>
					Learn More
				</a>
			</p>
		</div>
	</div>
	<div class='item'>
		<img src='/images/banner4.svg' alt='Microsoft Azure' class='img-responsive' />
		<div class='carousel-caption' role='option'>
			<p>
				Learn how Microsoft's Azure cloud platform allows you to build, deploy, and scale web apps.
				<a class='btn btn-default' href='http://go.microsoft.com/fwlink/?LinkID=525027&clcid=0x409'>
					Learn More
				</a>
			</p>
		</div>
	</div>
</div>
<a class='left carousel-control' href='#myCarousel' role='button' data-slide='prev'>
	<span class='glyphicon glyphicon-chevron-left' aria-hidden='true'></span>
	<span class='sr-only'>Previous</span>
</a>
<a class='right carousel-control' href='#myCarousel' role='button' data-slide='next'>
	<span class='glyphicon glyphicon-chevron-right' aria-hidden='true'></span>
	<span class='sr-only'>Next</span>
</a>
</div>",
                Pages = new List<Page> {
                    new Page {
                        Name = "Home",
                        Title = "Home Page",
                        Rows = new List<Row> {
                            new Row {
                                ClassName = "row",
                                Cols = new List<Col> {
                                    new Col {
                                        ClassName = "col-md-3",
                                        Modules = new List<Module> {
                                            new Module {
                                                Content = @"
<h2>Application uses</h2>
<ul>
	<li>Sample pages using ASP.NET Core MVC</li>
	<li><a href='http://go.microsoft.com/fwlink/?LinkId=518004'>Bower</a> for managing client-side libraries</li>
	<li>Theming using <a href='http://go.microsoft.com/fwlink/?LinkID=398939'>Bootstrap</a></li>
</ul>"
                                            }
                                        }
                                    },
                                    new Col {
                                        ClassName = "col-md-3",
                                        Modules = new List<Module> {
                                            new Module {
                                                Content = @"
<h2>How to</h2>
<ul>
	<li><a href='http://go.microsoft.com/fwlink/?LinkID=398600'>Add a Controller and View</a></li>
	<li><a href='http://go.microsoft.com/fwlink/?LinkID=699562'>Add an appsetting in config and access it in app.</a></li>
	<li><a href='http://go.microsoft.com/fwlink/?LinkId=699315'>Manage User Secrets using Secret Manager.</a></li>
	<li><a href='http://go.microsoft.com/fwlink/?LinkId=699316'>Use logging to log a message.</a></li>
	<li><a href='http://go.microsoft.com/fwlink/?LinkId=699317'>Add packages using NuGet.</a></li>
	<li><a href='http://go.microsoft.com/fwlink/?LinkId=699318'>Add client packages using Bower.</a></li>
	<li><a href='http://go.microsoft.com/fwlink/?LinkId=699319'>Target development, staging or production environment.</a></li>
</ul>"
                                            }
                                        }
                                    },
                                    new Col {
                                        ClassName = "col-md-3",
                                        Modules = new List<Module> {
                                            new Module {
                                                Content = @"
<h2>Overview</h2>
<ul>
	<li><a href='http://go.microsoft.com/fwlink/?LinkId=518008'>Conceptual overview of what is ASP.NET Core</a></li>
	<li><a href='http://go.microsoft.com/fwlink/?LinkId=699320'>Fundamentals of ASP.NET Core such as Startup and middleware.</a></li>
	<li><a href='http://go.microsoft.com/fwlink/?LinkId=398602'>Working with Data</a></li>
	<li><a href='http://go.microsoft.com/fwlink/?LinkId=398603'>Security</a></li>
	<li><a href='http://go.microsoft.com/fwlink/?LinkID=699321'>Client side development</a></li>
	<li><a href='http://go.microsoft.com/fwlink/?LinkID=699322'>Develop on different platforms</a></li>
	<li><a href='http://go.microsoft.com/fwlink/?LinkID=699323'>Read more on the documentation site</a></li>
</ul>"
                                            }
                                        }
                                    },
                                    new Col {
                                        ClassName = "col-md-3",
                                        Modules = new List<Module> {
                                            new Module {
                                                Content = @"
<h2>Run & Deploy</h2>
<ul>
	<li><a href='http://go.microsoft.com/fwlink/?LinkID=517851'>Run your app</a></li>
	<li><a href='http://go.microsoft.com/fwlink/?LinkID=517853'>Run tools such as EF migrations and more</a></li>
	<li><a href='http://go.microsoft.com/fwlink/?LinkID=398609'>Publish to Microsoft Azure Web Apps</a></li>
</ul>"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                    }
                    ,new Page {
                        Name = "Contact",
                        Title = "Contact Us",
                        Rows = new List<Row> {
                            new Row {
                                ClassName = "row",
                                Cols = new List<Col> {
                                    new Col {
                                        ClassName = "col-md-12",
                                        Modules = new List<Module> {
                                            new Module {
                                                Content = @"
<h3>How to find us?</h3>
<address>
    One Microsoft Way<br />
    Redmond, WA 98052-6399<br />
    <abbr title='Phone'>P:</abbr>
    425.555.0100
</address>

<address>
    <strong>Support:</strong> <a href='mailto:Support@example.com'>Support@example.com</a><br />
    <strong>Marketing:</strong> <a href='mailto:Marketing@example.com'>Marketing@example.com</a>
</address>"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                    }
                },
                FooterHtml = $"<hr /><p>&copy; {DateTime.Now.Year} - LiteApp</p>",
                Styles = new List<Style> {
                    new Style {
                        Path = "/lib/bootstrap/dist/css/bootstrap.css"
                    },
                    new Style {
                        Path = "/css/site.css"
                    }
                },
                ScriptsBottom = new List<Script> {
                    new Script {
                        Path = "/lib/jquery/dist/jquery.js"
                    },
                    new Script {
                        Path = "/lib/bootstrap/dist/js/bootstrap.js"
                    },
                    new Script {
                        Path = "/js/site.js"
                    }
                },
                NotFoundHtml = "<h1>Page Not Found</h1>"
            };

            return app;
        }
    }
}
