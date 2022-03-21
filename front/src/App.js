import './App.css';
import Navigation from './components/navigation';
import { LoginPage } from "./pages/Login/LoginPage";
import { RegistrationPage } from './pages/Registration/RegistrationPage';
import { HomePage } from './pages/Home/HomePage';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { CoursesPage } from './pages/Courses/CoursesPage';
import { UserCoursesPage } from './pages/User/UserCoursesPage';
import { UserPage } from './pages/User/UserPage';

export default function App() {

  return (
    <div className="App">
      <BrowserRouter>
        <Navigation />
        <Routes>
          <Route path="/courses" element={<CoursesPage />} />
          <Route index path="/" element={<HomePage />} />
        </Routes>
        <main className='form-signin'>
          <Routes>
            <Route path="/user" element={<UserPage />} />
            <Route path="/login" element={<LoginPage />} />
            <Route path="/registeration" element={<RegistrationPage />} />
          </Routes>
        </main>
      </BrowserRouter>
    </div>
  );
}