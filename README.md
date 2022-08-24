<i>PayCore .NET Core Bootcamp - 3. Hafta</i>

<hr />
<h3>Proje Hakkında</h4>
<ul>
    <li>.NET 6 ile geliştirilmiş bir ASP.NET Web API projesidir.</li>
    <li>Sınıflara ve barındırdığı özelliklere dair açıklamalar her dosyanın içerisinde yorum satırlarında detaylı olarak belirtilmiştir.</li>
    <li>Katmanlı bir yapı izlenerek oluşturulmuştur.</li>
    <li><a href="https://www.postgresql.org" target="_blank">PostgreSQL</a> veri tabanı kullanılmıştır.</li>
    <li><a href="https://nhibernate.info" target="_blank">NHibernate</a> ORM aracından yararlanılmıştır.</li>
    <li>Bütün action metodlarına ait ekran görüntülü sonuçlar en aşağıda yer almaktadır.</li>
    <li>Veritabanına ait script kodlarına <a href="" target="_blank">bu linkten</a> erişilebilir.</li>
</ul>

<hr />
<h3>Proje Yapısı</h4>
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
        <h3>Araç İşlemleri (VehiclesController)</h3>
        <ul>
            <li>
                <h4>Tüm araçları listeleme : [HttpGet("GetVehicles")] GetVehicles()</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
            </li>
            <li>
                <h4>Id'ye göre araç araması yapma : [HttpGet("GetVehicle/{id}")] GetVehicle(long? id)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
            </li>
            <li>
                <h4>Yeni bir araç ekleme : [HttpPost("AddVehicle")] AddVehicle([FromBody] Vehicle vehicle)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
            </li>
            <li>
                <h4>Mevcut bir aracı güncelleme : [HttpPut("UpdateVehicle")] UpdateVehicle([FromBody] Vehicle vehicle)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
            </li>
            <li>
                <h4>Id'si belirlenen bir aracı konteynerleri ile birlikte silme : [HttpDelete("DeleteVehicle/{id}")] DeleteVehicle(long? id)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
            </li>
        </ul>
    </li>
    <li><h3>Konteyner İşlemleri</h3>
        <ul>
            <li>
                <h4>Tüm konteynerleri listeleme : [HttpGet("GetContainers")] GetContainers()</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
            </li>
            <li>
                <h4>Id'ye göre konteyner araması yapma : [HttpGet("GetContainer/{id}")] GetContainer(long? id)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
            </li>
            <li>
                <h4>Araç numarasına göre konteynerları listeleme : [HttpGet("GetContainersByVehicleId/{vehicleId}")] GetContainersByVehicleId(long? vehicleId)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
            </li>
            <li>
                <h4>Araç numarası belirlenen konteynerleri belirlenen sayıda kümelere ayırarak listeleme : [HttpGet("GetClusteredContainers/{vehicleId}/{clusterCount}")] GetClusteredContainers(long? vehicleId, int clusterCount)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
            </li>
            <li>
                <h4>Yeni bir konteyner ekleme : [HttpPost("AddContainer")] AddContainer([FromBody] Container container)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
            </li>
            <li>
                <h4>Mevcut bir konteyneri güncelleme : [HttpPut("UpdateContainer")] UpdateContainer([FromBody] Container container)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
            </li>
            <li>
                <h4>Id'si belirlenen bir konteyneri silme : [HttpDelete("DeleteContainer/{id}")] DeleteContainer(long? id)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
            </li>
        </ul>
    </li>
</ul>
