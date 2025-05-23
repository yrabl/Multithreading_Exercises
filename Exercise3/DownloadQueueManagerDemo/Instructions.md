## 🧪 Exercise 3: **Download Queue Manager with Priority and Pausing**

### 🎯 Requirements:

Create a **console** or **WPF** application that simulates a **download manager** with a **priority queue**.

1. Simulate downloading **10 files**, but **only 3 downloads can run in parallel**.
2. Each file has a **random priority (1–3)** where 1 is **highest**.
3. Files with higher priority must start first (even if added later).
4. Each file should report **progress every 20%**.
5. Total download time is between **4–8 seconds**, broken into 5 steps.
6. At any point, the user can press:

   * `P` to **pause all downloads**
   * `R` to **resume**
   * `C` to **cancel all**
7. When a download completes, the next highest-priority file starts.

---

### 💡 Hints:

* Use a `PriorityQueue<FileDownload, int>` if using .NET 6+, or simulate one with a `SortedList<int, Queue<FileDownload>>`.
* Use a `SemaphoreSlim` to limit concurrency.
* Use `CancellationTokenSource` for cancellation.
* Track `isPaused` flag with a `ManualResetEventSlim`.

---

### 📦 Sample Output:

```
File 3 (Priority 1) started
File 5 (Priority 1) started
File 1 (Priority 2) started

File 3 progress: 20%
File 5 progress: 20%
File 1 progress: 20%
...

File 5 finished
File 4 (Priority 1) started
...

[Paused]
[Resumed]
[Cancelled]
```
