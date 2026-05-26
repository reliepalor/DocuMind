import { useState } from 'react';
import { getAuth, signInWithEmailAndPassword } from 'firebase/auth';
import { initializeApp } from 'firebase/app';


const firebaseConfig = {
  // ← Paste your Firebase config here
  apiKey: "AIzaSyD-kjZ_ClDLYW_vWyfwF6yZB7dNugm0bfI",
  authDomain: "documind-bccb7.firebaseapp.com",
  projectId: "documind-bccb7",
  storageBucket: "documind-bccb7.firebasestorage.app",
  messagingSenderId: "23402382005",
  appId: "1:23402382005:web:776dc528fa51dedbffb4fc",
  measurementId: "G-WRYHLEEGRE"

  // ... add the rest
};

const app = initializeApp(firebaseConfig);
const auth = getAuth(app);

function App() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [token, setToken] = useState("");

  const handleLogin = async () => {
    try {
      const userCredential = await signInWithEmailAndPassword(auth, email, password);
      const idToken = await userCredential.user.getIdToken();
      setToken(idToken);
      console.log("Token:", idToken);
      alert("Token copied to console! Use it in Postman.");
    } catch (error: any) {
      alert(error.message);
    }
  };

  return (
    <div style={{ padding: 20 }}>
      <h2>DocuMind - Firebase Test Login</h2>
      <input 
        type="email" 
        placeholder="Email" 
        value={email} 
        onChange={(e) => setEmail(e.target.value)} 
      /><br/><br/>
      <input 
        type="password" 
        placeholder="Password" 
        value={password} 
        onChange={(e) => setPassword(e.target.value)} 
      /><br/><br/>
      <button onClick={handleLogin}>Login & Get Token</button>
      
      {token && <p>Token generated! Check console.</p>}
    </div>
  );
}

export default App;