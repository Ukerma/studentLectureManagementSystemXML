<h1>🎓 Student and Lecture Management System (XML)</h1>
<p>
   <strong>Student and Lecture Management System</strong> is a console-based application developed in C# for managing students, instructors, and courses. The system allows administrators to add, edit, and delete data for each entity, assign courses to students or instructors, and manage the relationships between them. Data persistence is achieved using XML files.
</p>

<h2>🛠️ Features</h2>
<ul>
   <li> Add, edit, delete, and list students, instructors, and courses.</li>
   <li> Assign or remove courses for students and instructors.</li>
   <li> List detailed information about students, instructors, and courses, including their relationships.</li>
   <li> Persist all data in <code>XML</code> files.</li>
</ul>

<h2>⚙️ Technical Details</h2>
<ul>
   <li> Developed in <strong>C#</strong> using object-oriented programming principles.</li>
   <li> Data is stored and retrieved from <strong>XML files</strong> for persistence.</li>
   <li> Utilizes <code>XmlSerializer</code> for XML serialization and deserialization.</li>
</ul>

<h2>🚀 How to Use</h2>
<ol>
   <li> Open the project in Visual Studio or a compatible C# IDE.</li>
   <li> Build and run the application.</li>
   <li> Navigate through the menu to perform actions like adding students, instructors, or courses, or assigning courses to individuals.</li>
   <li> All changes will be automatically saved to the respective XML files when exiting.</li>
</ol>

<h2>📂 Project Structure</h2>
<p>The project is organized into the following main components:</p>
<ul>
   <li>
      <strong>Student:</strong>  
      Represents a student with properties like:
      <ul>
         <li><code>FirstName</code> and <code>LastName</code></li>
         <li><code>StudentID</code>: A unique identifier for each student.</li>
         <li><code>EnrolledCourses</code>: List of courses the student is enrolled in.</li>
      </ul>
   </li>
   <li>
      <strong>Instructor:</strong>  
      Represents an instructor with properties like:
      <ul>
         <li><code>FirstName</code> and <code>LastName</code></li>
         <li><code>Department</code>: The department the instructor belongs to.</li>
         <li><code>AssignedCourses</code>: List of courses assigned to the instructor.</li>
      </ul>
   </li>
   <li>
      <strong>Course:</strong>  
      Represents a course with properties like:
      <ul>
         <li><code>CourseName</code>: The name of the course.</li>
         <li><code>Credits</code>: Number of credits the course is worth.</li>
         <li><code>InstructorName</code>: The name of the instructor assigned to the course.</li>
         <li><code>EnrolledStudents</code>: List of students enrolled in the course.</li>
      </ul>
   </li>
   <li>
      <strong>Program:</strong>  
      The main class that contains menu-driven methods to interact with students, instructors, and courses.
   </li>
</ul>

<h2>👨‍💻 Author</h2> <p> This project was created by <strong>Umut Kerim ACAR (ukerma)</strong>. </p>

<h2>📜 Açıklama (Türkçe)</h2>
<p>
   <strong>Student and Lecture Management System</strong>, öğrencileri, eğitmenleri ve dersleri yönetmek için C# ile geliştirilmiş bir konsol tabanlı uygulamadır. Sistem, her bir varlık için veri ekleme, düzenleme ve silme işlemlerine ek olarak, öğrenciler ve eğitmenler için ders atama ve ilişkileri yönetme işlevlerini sunar. Veriler <strong>XML dosyaları</strong> ile kalıcı hale getirilir.
</p>

<h2>🛠️ Özellikler</h2>
<ul>
   <li> Öğrenci, eğitmen ve ders kayıtlarını ekleme, düzenleme, silme ve listeleme.</li>
   <li> Öğrencilere ve eğitmenlere ders atama veya ders kaldırma.</li>
   <li> Öğrenci, eğitmen ve derslerin detaylı bilgilerini listeleme.</li>
   <li> Tüm veriler <code>XML</code> dosyalarında saklanır.</li>
</ul>

<h2>⚙️ Teknik Detaylar</h2>
<ul>
   <li> <strong>C#</strong> ile nesne yönelimli programlama prensipleri kullanılarak geliştirilmiştir.</li>
   <li> Veriler <strong>XML dosyalarında</strong> saklanır ve yüklenir.</li>
   <li> XML işlemleri için <code>XmlSerializer</code> kullanılmıştır.</li>
</ul>

<h2>🚀 Nasıl Kullanılır</h2>
<ol>
   <li> Projeyi Visual Studio veya uyumlu bir C# IDE'sinde açın.</li>
   <li> Uygulamayı derleyin ve çalıştırın.</li>
   <li> Menü üzerinden öğrenciler, eğitmenler veya derslerle ilgili işlemleri gerçekleştirin.</li>
   <li> Çıkış yaptığınızda tüm veriler ilgili XML dosyalarına kaydedilecektir.</li>
</ol>

<h2>📂 Proje Yapısı</h2>
<p>Proje şu ana bileşenlerden oluşmaktadır:</p>
<ul>
   <li>
      <strong>Student:</strong>  
      Öğrencileri temsil eder. Aşağıdaki özellikleri içerir:
      <ul>
         <li><code>FirstName</code> ve <code>LastName</code>: Öğrencinin adı ve soyadı.</li>
         <li><code>StudentID</code>: Öğrencinin benzersiz kimlik numarası.</li>
         <li><code>EnrolledCourses</code>: Öğrencinin kayıtlı olduğu derslerin listesi.</li>
      </ul>
   </li>
   <li>
      <strong>Instructor:</strong>  
      Eğitmenleri temsil eder. Aşağıdaki özellikleri içerir:
      <ul>
         <li><code>FirstName</code> ve <code>LastName</code>: Eğitmenin adı ve soyadı.</li>
         <li><code>Department</code>: Eğitmenin bağlı olduğu bölüm.</li>
         <li><code>AssignedCourses</code>: Eğitmene atanan derslerin listesi.</li>
      </ul>
   </li>
   <li>
      <strong>Course:</strong>  
      Dersleri temsil eder. Aşağıdaki özellikleri içerir:
      <ul>
         <li><code>CourseName</code>: Dersin adı.</li>
         <li><code>Credits</code>: Dersin kredi sayısı.</li>
         <li><code>InstructorName</code>: Derse atanmış eğitmenin adı.</li>
         <li><code>EnrolledStudents</code>: Derse kayıtlı öğrencilerin listesi.</li>
      </ul>
   </li>
   <li>
      <strong>Program:</strong>  
      Öğrenciler, eğitmenler ve derslerle etkileşim için menü tabanlı işlemleri içerir.
   </li>
</ul>

<h2>👨‍💻 Yazar</h2> <p> Bu proje, <strong>Umut Kerim ACAR (ukerma)</strong> tarafından <strong> yapılmıştır. </p>
