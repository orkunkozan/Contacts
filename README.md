* Rabit MQ  instancesi gerekmektedir.
* DB olarak Postgresql Instancesi gerekmektedir.

* Yukardaki iki instance i�in ilgili ms lerin appsetting lerinde gerekli d�zenlemeler yap�lmal�d�r.
D�zenlenecek  scopelar ��yledir : CapConfig  &   ConnectionStrings:PostgresContext     

* MS ileti�imi   https://localhost:7140/myCap/index.html   &&  https://localhost:7138/mycap/index.html  
adresleri �zerinden takip edebilirsiniz.


2 tane MS  olu�turuldu. 

Contact  MS  varl�klar� :  Ki�iler ve �leti�im Bilgileridir.

Report MS  varl�klar� : Raporlar ve Rapor Datalar� d�r.
Ek olarak  readonly   Ki�iler ve �leti�im bilgileri di�er MS �zerinden async olarak Report MS ye akmaktad�r.

�leti�imi sa�layan CAP k�t�phanesidir.  Microservice mimarisi olarak event driven yakla��m benimsenmi�tir.
Ek olarak CAP in sundu�u OUTBOX battern uygulanm��t�r. 

Proje Mimarisi olarak CQRS + Mediator  

Pipeline Behaver  AOP uygulanm��t�r.