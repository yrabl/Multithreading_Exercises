## 🧪 Exercise 1: **Simulated Parallel File Downloads with Status Updates**

### 🎯 Requirements:

1. Write a console or WPF application that simulates downloading 5 files.
2. Each "download" takes 2–5 seconds (randomly).
3. Each file runs on a separate thread.
4. When a download finishes – print to the screen which file finished and when.
5. Wait for all downloads to complete.

---

### 💡 Hints:

* Use `Task` or `Thread`
* Simulate delay using `Task.Delay` or `Thread.Sleep`
* For showing time – use `DateTime.Now`

---

### 📦 Sample Output:

```
Start downloading file 1
Start downloading file 2
Start downloading file 3
Start downloading file 4
Start downloading file 5

File 3 finished at 10:22:01
File 1 finished at 10:22:02
File 4 finished at 10:22:03
File 2 finished at 10:22:04
File 5 finished at 10:22:05
```
