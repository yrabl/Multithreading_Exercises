## 🧪 Exercise 2: **Simulated File Downloads with Progress Reporting and Cancellation**

### 🎯 Requirements:

1. Write a **console** or **WPF** application that simulates downloading 5 files.
2. Each file should report **progress every 10%** (i.e., 10 updates per file).
3. The total simulated time for a download should be between **3–6 seconds**, divided into 10 equal steps.
4. Each file download runs on a **separate thread or task**.
5. Show the progress in the format:

   ```
   File 1 progress: 10%
   File 1 progress: 20%
   ...
   File 1 finished at 10:22:01
   ```
6. Add a **cancellation mechanism** that stops all downloads if the user presses a key (e.g., `Esc`).

---

### 💡 Hints:

* Use `Task`, `async/await`, and `CancellationTokenSource`.
* For delays: `Task.Delay(stepDuration, cancellationToken)`.
* For real-time key monitoring in a console app: `Console.KeyAvailable` + `Console.ReadKey(true)`.
* Consider using `lock` or `ConcurrentQueue` to manage synchronized output.

---

### 📦 Sample Output:

```
Starting download for file 1
Starting download for file 2
...

File 1 progress: 10%
File 2 progress: 10%
File 1 progress: 20%
File 2 progress: 20%
...

File 1 finished at 10:22:01
File 3 cancelled
File 4 cancelled
```
