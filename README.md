<i>PayCore .NET Core Bootcamp - 3. Hafta</i>

<hr />
<h3>Proje Yapısı</h4>
<ul>
    <li>.NET 6 ile geliştirilmiş bir ASP.NET Web API projesidir.</li>
    <li>Sınıflara ve barındırdığı özelliklere dair açıklamalar her dosyanın içerisinde detaylı olarak belirtilmiştir.</li>
    <li>Katmanlı bir yapı izlenerek oluşturulmuştur.</li>
    <li>PostgreSQL veri tabanı kullanılmıştır.</li>
    <li>NHibernate ORM aracından yararlanılmıştır.</li>
    <li>Bütün action metodlarına ait ekran görüntülü sonuçlar en aşağıda yer almaktadır.</li>
</ul>

<hr />
<h3>Görev Listesi</h4>
<ul>
    <li>Core
        <ul>
            <li>API
                <ul>
                    <li>Abstract
                        <ul>
                            <li><a href="" target="_blank"><b>ICoreController.cs</b></a></li>
                        </ul>
                    </li>
                    <li>Concrete
                        <ul>
                            <li>Controllers
                                <ul>
                                    <li><a href="" target="_blank"><b>CoreController.cs</b></a></li>
                                </ul>
                            </li>
                            <li>Extensions
                                <ul>
                                    <li><a href="" target="_blank"><b>NHibernateExtension.cs</b></a></li>
                                </ul>
                            </li>
                        </ul>
                    </li>
                </ul>
            </li>
            <li>Data Access
                <ul>
                    <li>Abstract
                        <ul>
                            <li><a href="" target="_blank"><b>ICoreSession.cs</b></a></li>
                        </ul>
                    </li>
                    <li>Concrete
                        <ul>
                            <li><a href="" target="_blank"><b>CoreSession.cs</b></a></li>
                        </ul>
                    </li>
                </ul>
            </li>
            <li>Entity
                <ul>
                    <li>Abstract
                        <ul>
                            <li><a href="" target="_blank"><b>ICoreEntity.cs</b></a></li>
                        </ul>
                    </li>
                    <li>Concrete
                        <ul>
                            <li><a href="" target="_blank"><b>CoreEntity.cs</b></a></li>
                        </ul>
                    </li>
                </ul>
            </li>
        </ul>
    </li>
    <li>Data Access
        <ul>
            <li>Abstract
                <ul>
                    <li><a href="" target="_blank"><b>IContainerSession.cs</b></a></li>
                    <li><a href="" target="_blank"><b>IVehicleSession.cs</b></a></li>
                </ul>
            </li>
            <li>Concrete
                <ul>
                    <li><a href="" target="_blank"><b>ContainerSession.cs</b></a></li>
                    <li><a href="" target="_blank"><b>VehicleSession.cs</b></a></li>
                </ul>
            </li>
        </ul>
    </li>
    <li>Entity
        <ul>
            <li>Concrete
                <ul>
                    <li>Entities
                        <ul>
                            <li><a href="" target="_blank"><b>Container.cs</b></a></li>
                            <li><a href="" target="_blank"><b>Vehicle.cs</b></a></li>
                        </ul>
                    </li>
                    <li>Mappings
                        <ul>
                            <li><a href="" target="_blank"><b>ContainerMap.cs</b></a></li>
                            <li><a href="" target="_blank"><b>VehicleMap.cs</b></a></li>
                        </ul>
                    </li>
                </ul>
            </li>
        </ul>
    </li>
    <li>Web API
        <ul>
            <li>Controllers
                <ul>
                    <li><a href="" target="_blank"><b>ContainersController.cs</b></a></li>
                    <li><a href="" target="_blank"><b>VehiclesController.cs</b></a></li>
                </ul>
            </li>
            <li><a href="" target="_blank"><b>Program.cs</b></a></li>
            <li><a href="" target="_blank"><b>appsettings.json</b></a></li>
        </ul>
    </li>
</ul>

<hr />
<h3><b>Sonuçlara Ait Ekran Görüntüleri</b></h2>
<ul>
<li>
<h4>Title : Action Method</h4>
<p dir="auto"><a target="_blank" rel="noopener noreferrer" href=""><img src="" alt="Swagger" style="max-width: 100%;"></a></p>
</li>
