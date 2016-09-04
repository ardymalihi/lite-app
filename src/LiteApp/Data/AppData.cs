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
                Pages = new List<Page> {
                    new Page {
                        Route = "/",
                        Title = "Home Page",
                        Rows = new List<Row> {
                            new Row {
                                Cols = new List<Col> {
                                    new Col {
                                        Modules = new List<IModule> {
                                            new MenuModule {
                                                MenuItems = new List<MenuItem> {
                                                    new MenuItem {
                                                        Title = "Home",
                                                        Route = "/"
                                                    },
                                                    new MenuItem {
                                                        Title = "Contact Us",
                                                        Route = "/contact"
                                                    },
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new Row {
                                Cols = new List<Col> {
                                    new Col {
                                        Modules = new List<IModule> {
                                            new HtmlModule {
                                                Content = "<h2>Module Left</h2>"
                                            }
                                        }
                                    },
                                    new Col {
                                        Modules = new List<IModule> {
                                            new HtmlModule {
                                                Content = "<h2>Module Right Top</h2>"
                                            },
                                            new HtmlModule {
                                                Content = "<h2>Module Right Bottom</h2>"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                    }
                    ,new Page {
                        Route = "/contact",
                        Title = "Contact Us",
                        Rows = new List<Row> {
                            new Row {
                                Cols = new List<Col> {
                                    new Col {
                                        Modules = new List<IModule> {
                                            new HtmlModule {

                                            }
                                        }
                                    }
                                }
                            }
                        },
                    }
                }
            };

            return app;
        }
    }
}
