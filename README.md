This is a test project for GitHub bug https://github.com/dotnet/runtime/issues/108762

Below is the list of projects:
Test.Maui.7 -> DotNet 7 Maui app (no leak - See results below after 10 min)
![image](https://github.com/user-attachments/assets/5ca3cc11-2f16-4cd2-912f-d3f8b3ef692f)

Test.Maui.8 -> DotNet 8 Maui app (leak detected - See results below after 10 min)
![image](https://github.com/user-attachments/assets/de688d8e-bb85-450b-8cec-33cec248bf89)

Test.Android.7 -> DotNet 7 Android app (no leak - See results below after 3 min)
![image](https://github.com/user-attachments/assets/853fad3f-1e4d-47e9-9c9c-cd88af0db137)

Test.Android.8 -> DotNet 8 Android app (leak detected - See results below after 3 min)
![image](https://github.com/user-attachments/assets/d1f1934c-4d88-4bda-b116-afdc2325a039)

Test.Console.8 -> DotNet 8 Console app (no leak - See results below after 3 min)
![image](https://github.com/user-attachments/assets/902f993e-e504-4132-932f-142dd7794736)
