<i>PayCore .NET Core Bootcamp - 3. Hafta</i>

<hr />
<h2>Proje Hakkında</h2>
<ul>
    <li>.NET 6 ile geliştirilmiş bir ASP.NET Web API projesidir.</li>
    <li>Sınıflara ve barındırdığı özelliklere dair açıklamalar her dosyanın içerisinde yorum satırlarında detaylı olarak belirtilmiştir.</li>
    <li>Katmanlı bir yapı izlenerek oluşturulmuştur.</li>
    <li><a href="https://www.postgresql.org" target="_blank">PostgreSQL</a> veri tabanı kullanılmıştır.</li>
    <li><a href="https://nhibernate.info" target="_blank">NHibernate</a> ORM aracından yararlanılmıştır.</li>
    <li>Bütün action metodlarına ait ekran görüntülü sonuçlar en aşağıda yer almaktadır.</li>
    <li>Veritabanına ait script kodlarına <a href="https://pastebin.com/pk7mtrZz" target="_blank">bu linkten</a> erişilebilir. (VPN gerekebilir.)</li>
</ul>

<hr />
<h2>Proje Yapısı</h2>
<ul>
    <li>Core
        <ul>
            <li>API
                <ul>
                    <li>Abstract
                        <ul>
                            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/Core/API/Abstract/ICoreController.cs" target="_blank"><b>ICoreController.cs</b></a></li>
                        </ul>
                    </li>
                    <li>Concrete
                        <ul>
                            <li>Controllers
                                <ul>
                                    <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/Core/API/Concrete/Controllers/CoreController.cs" target="_blank"><b>CoreController.cs</b></a></li>
                                </ul>
                            </li>
                            <li>Extensions
                                <ul>
                                    <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/Core/API/Concrete/Extensions/NHibernateExtension.cs" target="_blank"><b>NHibernateExtension.cs</b></a></li>
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
                            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/Core/DataAccess/Abstract/ICoreSession.cs" target="_blank"><b>ICoreSession.cs</b></a></li>
                        </ul>
                    </li>
                    <li>Concrete
                        <ul>
                            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/Core/DataAccess/Concrete/CoreSession.cs" target="_blank"><b>CoreSession.cs</b></a></li>
                        </ul>
                    </li>
                </ul>
            </li>
            <li>Entity
                <ul>
                    <li>Abstract
                        <ul>
                            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/Core/Entity/Abstract/ICoreEntity.cs" target="_blank"><b>ICoreEntity.cs</b></a></li>
                        </ul>
                    </li>
                    <li>Concrete
                        <ul>
                            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/Core/Entity/Concrete/CoreEntity.cs" target="_blank"><b>CoreEntity.cs</b></a></li>
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
                    <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/DataAccess/Abstract/IContainerSession.cs" target="_blank"><b>IContainerSession.cs</b></a></li>
                    <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/DataAccess/Abstract/IVehicleSession.cs" target="_blank"><b>IVehicleSession.cs</b></a></li>
                </ul>
            </li>
            <li>Concrete
                <ul>
                    <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/DataAccess/Concrete/ContainerSession.cs" target="_blank"><b>ContainerSession.cs</b></a></li>
                    <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/DataAccess/Concrete/VehicleSession.cs" target="_blank"><b>VehicleSession.cs</b></a></li>
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
                            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/Entity/Concrete/Entities/Container.cs" target="_blank"><b>Container.cs</b></a></li>
                            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/Entity/Concrete/Entities/Vehicle.cs" target="_blank"><b>Vehicle.cs</b></a></li>
                        </ul>
                    </li>
                    <li>Mappings
                        <ul>
                            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/Entity/Concrete/Mappings/ContainerMap.cs" target="_blank"><b>ContainerMap.cs</b></a></li>
                            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/Entity/Concrete/Mappings/VehicleMap.cs" target="_blank"><b>VehicleMap.cs</b></a></li>
                        </ul>
                    </li>
                </ul>
            </li>
        </ul>
    </li>
    <li>API
        <ul>
            <li>Controllers
                <ul>
                    <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/Controllers/ContainersController.cs" target="_blank"><b>ContainersController.cs</b></a></li>
                    <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/Controllers/VehiclesController.cs" target="_blank"><b>VehiclesController.cs</b></a></li>
                </ul>
            </li>
            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/Program.cs" target="_blank"><b>Program.cs</b></a></li>
            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta3/blob/main/PayCoreClassWork3/PayCoreClassWork3.WebAPI/appsettings.json" target="_blank"><b>appsettings.json</b></a></li>
        </ul>
    </li>
</ul>

<hr />
<h2><b>Sonuçlara Ait Ekran Görüntüleri</b></h2>
<ul>
    <li>
        <h3>Tüm İşlemler</h3>
        <p dir="auto">
            <a target="_blank" rel="noopener noreferrer" href="">
                <img src="https://i.hizliresim.com/lrfo9dj.png" alt="Swagger" style="max-width: 100%;">
            </a>
        </p>
    </li>
    <li>
        <h3>Araç İşlemleri (VehiclesController)</h3>
        <ul>
            <li>
                <h4>Tüm araçları listeleme : [HttpGet("GetVehicles")] GetVehicles()</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/8jgi9y8.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
            </li>
            <li>
                <h4>Id'ye göre araç araması yapma : [HttpGet("GetVehicle/{id}")] GetVehicle(long? id)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/58o96s5.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/5xbulmi.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
            </li>
            <li>
                <h4>Yeni bir araç ekleme : [HttpPost("AddVehicle")] AddVehicle([FromBody] Vehicle vehicle)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/4enjzal.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
            </li>
            <li>
                <h4>Mevcut bir aracı güncelleme : [HttpPut("UpdateVehicle")] UpdateVehicle([FromBody] Vehicle vehicle)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/24t2rke.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/p6jhh54.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
            </li>
            <li>
                <h4>Id'si belirlenen bir aracı konteynerleri ile birlikte silme : [HttpDelete("DeleteVehicle/{id}")] DeleteVehicle(long? id)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/4b0p8x5.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/htwpum1.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/ikmkp49.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/4hib7b5.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
            </li>
        </ul>
    </li>
    <li>
        <h3>Konteyner İşlemleri (ContainersController)</h3>
        <ul>
            <li>
                <h4>Tüm konteynerleri listeleme : [HttpGet("GetContainers")] GetContainers()</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/izl2uyd.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
            </li>
            <li>
                <h4>Id'ye göre konteyner araması yapma : [HttpGet("GetContainer/{id}")] GetContainer(long? id)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/b2feztm.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/b67elm6.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
            </li>
            <li>
                <h4>Araç numarasına göre konteynerları listeleme : [HttpGet("GetContainersByVehicleId/{vehicleId}")] GetContainersByVehicleId(long? vehicleId)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/la6jir3.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/pzr9o6m.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
            </li>
            <li>
                <h4>Araç numarası belirlenen konteynerleri belirlenen sayıda kümelere ayırarak listeleme : [HttpGet("GetClusteredContainers/{vehicleId}/{clusterCount}")] GetClusteredContainers(long? vehicleId, int clusterCount)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/oc73rhj.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/3rgud8t.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/fg0188f.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/g170391.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
            </li>
            <li>
                <h4>Yeni bir konteyner ekleme : [HttpPost("AddContainer")] AddContainer([FromBody] Container container)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/obzvum6.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
            </li>
            <li>
                <h4>Mevcut bir konteyneri güncelleme : [HttpPut("UpdateContainer")] UpdateContainer([FromBody] Container container)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/d5l3scn.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/l788onf.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
            </li>
            <li>
                <h4>Id'si belirlenen bir konteyneri silme : [HttpDelete("DeleteContainer/{id}")] DeleteContainer(long? id)</h4>
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/t2dr2lf.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
                <br />
                <p dir="auto">
                    <a target="_blank" rel="noopener noreferrer" href="">
                        <img src="https://i.hizliresim.com/lfdrvmq.png" alt="Swagger" style="max-width: 100%;">
                    </a>
                </p>
            </li>
        </ul>
    </li>
</ul>
