import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import Navbar from './Components/Navbar/Navbar';
import Home from './Pages/Home/Home';
import Login from './Pages/Login/Login';
import Categories from './Pages/Categories/Categories';
import './styles/index.scss';
import Books from './Pages/Books/Books';
import BorrowBooks from './Pages/BorrowBooks/BorrowBooks';

const App = () => {
  const router = createBrowserRouter([
    {
      path: '/',
      element: <Navbar />,
      children: [
        {
          index: true,
          element: <Home />,
        },
        {
          path: '/categories',
          element: <Categories />,
        },
        {
          path: '/books',
          element: <Books />,
        },
        {
          path: '/borrow-books',
          element: <BorrowBooks />,
        },
        {
          path: '/login',
          element: <Login />,
        },
      ],
    },
  ]);

  return <RouterProvider router={router} />;
};

export default App;
