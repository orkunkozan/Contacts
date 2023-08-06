* Rabit MQ  instancesi gerekmektedir.
* DB olarak Postgresql Instancesi gerekmektedir.

* Yukardaki iki instance için ilgili ms lerin appsetting lerinde gerekli düzenlemeler yapýlmalýdýr.
Düzenlenecek  scopelar þöyledir : CapConfig  &   ConnectionStrings:PostgresContext     

* MS iletiþimi   https://localhost:7140/myCap/index.html   &&  https://localhost:7138/mycap/index.html  
adresleri üzerinden takip edebilirsiniz.


2 tane MS  oluþturuldu. 

Contact  MS  varlýklarý :  Kiþiler ve Ýletiþim Bilgileridir.

Report MS  varlýklarý : Raporlar ve Rapor Datalarý dýr.
Ek olarak  readonly   Kiþiler ve Ýletiþim bilgileri diðer MS üzerinden async olarak Report MS ye akmaktadýr.

Ýletiþimi saðlayan CAP kütüphanesidir.  Microservice mimarisi olarak event driven yaklaþým benimsenmiþtir.
Ek olarak CAP in sunduðu OUTBOX battern uygulanmýþtýr. 

Proje Mimarisi olarak CQRS + Mediator  

Pipeline Behaver  AOP uygulanmýþtýr.