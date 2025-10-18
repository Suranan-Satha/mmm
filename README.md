# โปรเจคเกม 2D Platformer

นี่คือโปรเจคเกม 2D Platformer พื้นฐานที่สร้างด้วย Unity Engine โดยใช้ Input System ใหม่ในการควบคุมตัวละคร ผู้เล่นสามารถบังคับตัวละครให้เดิน, กระโดด, รับความเสียหายจากศตรูหรือกับดัก และตายเมื่อพลังชีวิตหมด

## ✨ คุณสมบัติหลัก (Features)

* **การควบคุมตัวละคร (Player Control):**
    * เคลื่อนที่ซ้าย-ขวาด้วยปุ่ม `A` และ `D`
    * กระโดดด้วยปุ่ม `Spacebar`
    * ตัวละครจะพลิกด้าน (Flip) ตามทิศทางการเคลื่อนที่โดยอัตโนมัติ
* **ระบบพลังชีวิตและการตาย (Health & Death System):**
    * ผู้เล่นมีค่าพลังชีวิต (`health`) และสามารถรับความเสียหายได้ (`TakeDamage`)
    * เมื่อได้รับความเสียหาย จะมีแอนิเมชันแสดงอาการบาดเจ็บ และมีช่วงเวลาสั้นๆ ที่ไม่สามารถรับความเสียหายซ้ำได้
    * เมื่อพลังชีวิตหมด (`health <= 0`) ตัวละครจะเข้าสู่สถานะตาย การควบคุมทั้งหมดจะถูกปิดใช้งาน (`DisableControls`) และหน้าจอ Game Over จะแสดงขึ้นมา
* **ศัตรูและอุปสรรค (Enemies & Hazards):**
    * มีโค้ดสำหรับศัตรู (`EnemyAttack.cs`) และกับดักหนาม (`Spikes.cs`) ที่สามารถสร้างความเสียหายให้กับผู้เล่นได้
    * กับดักหนามสามารถทำให้ผู้เล่นกระเด็นถอยหลังได้ (Knockback)
* **ศัตรูและการโจมตี (Enemies & Combat):**
    * ศัตรูสามารถเดินและโจมตีผู้เล่นได้
    * ศัตรูมีแอนิเมชันเดินและโจมตี
    * เมื่อศัตรูโจมตี ผู้เล่นจะลดพลังชีวิตและเล่นแอนิเมชันบาดเจ็บ

## 🔧 โครงสร้างโค้ดที่สำคัญ

* `Controls.cs`: ไฟล์ที่สร้างขึ้นโดยอัตโนมัติจาก Unity Input System เพื่อจัดการ Action Map และ Bindings ของผู้เล่น (Move, Jump)
* `GatherInput.cs`: สคริปต์สำหรับรวบรวมข้อมูลการกดปุ่มจากผู้เล่น แล้วส่งค่าไปยังสคริปต์อื่น
* `PlayerMoveControls.cs`: สคริปต์หลักที่ควบคุมการเคลื่อนไหวของตัวละคร เช่น การเดิน, การกระโดด, การ Flip และการ Knockback
* `PlayerStats.cs`: จัดการค่าพลังชีวิตของผู้เล่น การรับความเสียหาย และเงื่อนไขการตาย
* `Enemy.cs`: ควบคุมการเคลื่อนที่, แอนิเมชันเดิน และโจมตีผู้เล่น
* `Spikes.cs` / `EnemyAttack.cs`: สคริปต์ตัวอย่างสำหรับออบเจกต์ที่สามารถสร้างความเสียหายแก่ผู้เล่นได้
* `HealthBar.cs`: ควบคุมการทำงานของ UI Slider และ Text เพื่อแสดงค่าพลังชีวิต
* `GameOverUI.cs`: จัดการการแสดงผลของหน้าจอ Game Over และฟังก์ชันการ Restart เกม

## 🖼️ ภาพหน้าจอการทำงาน (Screenshots)

### 🧍 ยืน (Idle)

แสดงภาพหน้าจอเมื่อตัวละครยืนอยู่กับที่ ไม่มีการเคลื่อนไหว

<img width="1247" height="635" alt="image" src="https://github.com/user-attachments/assets/2371bc72-63ae-4eaa-9b98-fc388177b456" />


### 🏃 เดินหน้า และกลับหลัง (Walking)

แสดงภาพหน้าจอเมื่อตัวละครกำลังเคลื่อนที่ไปทางซ้ายหรือขวา

<img width="1243" height="570" alt="image" src="https://github.com/user-attachments/assets/257eee69-b24f-4839-954b-e1f0b7ef6290" />
<img width="1044" height="493" alt="image" src="https://github.com/user-attachments/assets/c38f3825-6f6b-4cca-b26a-afb44c4d9e37" />



### 🤸 กระโดด (Jumping)

แสดงภาพหน้าจอเมื่อตัวละครกำลังลอยตัวอยู่กลางอากาศหลังจากการกระโดด

<img width="720" height="393" alt="image" src="https://github.com/user-attachments/assets/80698562-d4ea-482d-b912-1187f9c05565" />
<img width="800" height="378" alt="image" src="https://github.com/user-attachments/assets/f4933ce4-189f-4691-bfa2-5208e1ab2356" />

### 😎 ศัตรู (Enemy)

แสดงภาพหน้าจอเมื่อศัตรูเดินและทำดาเมจต่อผู้เล่นและเมื่อตัวละครผู้เล่นได้รับความเสียหาย ให้ทำการลดเลือดและเล่นอนิเมชั่นของตัวละครผู้เล่น
<img width="801" height="403" alt="image" src="https://github.com/user-attachments/assets/e0676852-d57a-469f-9c04-fac68137090f" />
<img width="1103" height="563" alt="image" src="https://github.com/user-attachments/assets/5d0ab9df-c371-4c19-a9d0-649f28243487" />



### ❤️‍🩹 บาดเจ็บ (Hurt / Taking Damage)

แสดงภาพหน้าจอขณะที่ตัวละครได้รับความเสียหาย (อาจจะมีเอฟเฟกต์กระพริบหรือแอนิเมชันแสดงความเจ็บปวด)

<img width="988" height="492" alt="image" src="https://github.com/user-attachments/assets/8fb7b56e-c9cc-43d6-a1bc-e60ec4ba9b8b" />


### 💀 ตาย (Death)

แสดงภาพหน้าจอเมื่อพลังชีวิตของตัวละครหมดลง ตัวละครจะเล่นแอนิเมชันตายและหยุดนิ่ง ไม่สามารถควบคุมได้อีกต่อไป

<img width="1037" height="628" alt="image" src="https://github.com/user-attachments/assets/cea3cd9f-5791-4925-ad50-b70fb99530ed" />

## 📊 ระบบ UI  (UI System)

### แสดงเลือดของตัวละคร (Health Bar Display)

โปรเจคนี้มีระบบ UI สำหรับแสดงพลังชีวิตของผู้เล่น ซึ่งควบคุมโดยสคริปต์ `HealthBar.cs`
* ใช้ UI **Slider** เพื่อแสดงแถบพลังชีวิต และ **Text** เพื่อแสดงค่าพลังชีวิตเป็นตัวเลข (เช่น "100 / 100")
* เมื่อมีการเปลี่ยนแปลงพลังชีวิต แถบ Slider จะลดลงอย่างนุ่มนวล (Smooth Change) แทนที่จะลดลงทันที

<img width="1715" height="826" alt="image" src="https://github.com/user-attachments/assets/ec0d755d-44b4-4be1-b076-eabb0c220286" />


### ลดเลือดของตัวละครเมื่อได้รับบาดเจ็บ (Health Reduction on Damage)

การลดพลังชีวิตถูกจัดการในสคริปต์ `PlayerStats.cs`
1.  เมื่อผู้เล่นโดนโจมตี, เมธอด `TakeDamage(float damage)` จะถูกเรียก
2.  ค่า `health` ของผู้เล่นจะถูกลดลงตาม `damage` ที่ได้รับ
3.  สคริปต์จะเรียกใช้ `healthBar.SetHealth(health)` เพื่ออัปเดต UI ให้ตรงกับพลังชีวิตปัจจุบัน
4.  หลังจากได้รับความเสียหาย จะมีช่วงเวลาสั้นๆ ที่ผู้เล่นเป็นอมตะ (invulnerable) เพื่อป้องกันการโดนโจมตีซ้ำๆ ทันที

<img width="1737" height="854" alt="image" src="https://github.com/user-attachments/assets/c09330f4-1539-4311-91ef-5728fc0b25c6" />


### และแสดงข้อความ Game Over (Game Over Screen)

เมื่อพลังชีวิตของผู้เล่นลดลงเหลือ 0 หรือน้อยกว่า
1.  สคริปต์ `PlayerStats.cs` จะตรวจจับว่าผู้เล่นตายแล้ว
2.  จากนั้นจะเรียกเมธอด `ShowGameOver()` จากสคริปต์ `GameOverUI.cs`
3.  `GameOverUI.cs` จะสั่งให้ `gameOverPanel` (ซึ่งถูกซ่อนไว้ในตอนแรก) แสดงผลขึ้นมา
4.  ผู้เล่นสามารถกดปุ่มบนหน้าจอ Game Over เพื่อเรียกใช้ฟังก์ชัน `RestartLevel()` เพื่อเริ่มต้นด่านใหม่ได้
<img width="1514" height="833" alt="image" src="https://github.com/user-attachments/assets/057c5b1c-7403-4c5b-b191-6d2630307ae3" />

