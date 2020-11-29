-Çalýþtýrmak için Docker Desktop kurulu olmalýdýr.
-Projenin root'unda alttaki komut çalýþtýrýlarak proje ayaða kaldýrýlabilir.
	-docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

- http://localhost:9000/swagger/index.html linkinden swagger sayfasýndan endpointler incelenebilir.

- Post methoduda nullable alanalr sayfanýn sonundaki RideViewModel'de gözlenebilir.

-Þehirler kordinat olarak girilmeli.
	Örnek:
		Beggining: "0,1"
		Destination: "3,3"

-Güzergahlar aranýrken tüm yollarý kapsayacak þekilde arama yaptým. 
Basitçe verilen kordinatlarýn x ve y aralýklarýnda olan tüm seyehatleri getirdim. 
Arama yaparken o düzlemde gitti yön -aþaðý/yukarý veya sola/saða gitmesi- dikkate alýndý.