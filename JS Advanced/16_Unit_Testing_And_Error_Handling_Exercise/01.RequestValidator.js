function requestValidator(obj){
    const method = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const urlRegex = /(^[\w.]+$)/gm;
    const version = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    const messageRegex = /[<>&'"\\]/gm;

    if(!obj.hasOwnProperty('method') || !method.includes(obj.method)){
        throw new Error('Invalid request header: Invalid Method');
    }

    if(!obj.hasOwnProperty('uri') || !urlRegex.test(obj.uri)){
        throw new Error('Invalid request header: Invalid URI');
    }

    if (!obj.hasOwnProperty('version') || !version.includes(obj.version)){
        throw new Error('Invalid request header: Invalid Version');
    }
    
    if (!obj.hasOwnProperty('message') || messageRegex.test(obj.message)) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return obj;
}

console.log(requestValidator({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
  }));