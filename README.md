# EmployeeManagement
Dot Net Core 3.1 Demo

# Session Cookie vs Persistent Cookie

Upon a successful login, a cookie is issued and this cookie is sent with each request to the server. The server uses this cookie to know that the user is already authenticated and logged-in. This cookie can either be a session cookie or a persistent cookie.

A session cookie is created and stored within the session instance of the browser. A session cookie does not contain an expiration date and is permanently deleted when the browser window is closed.

A persistent cookie on the other hand is not deleted when the browser window is closed. It usually has an expiry date and deleted on the date of expiry.
