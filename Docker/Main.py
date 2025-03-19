from flask import Flask

app = Flask(__name__)

@app.route('/')
def hello_world():
    return 'Hola flask'

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=8000)

#docker build -t hello-world-app .
#docker run --rm -p 8000:8000 hello-world-app