# -*- coding: utf-8 -*-
#KostasV-2018
import numpy as np
import math
import pandas as pd
import matplotlib.pyplot as plt
from sklearn.decomposition import PCA as sklearnPCA
from sklearn.preprocessing import MinMaxScaler

import re
import sys



class perceptron:
     
    def __init__(self, size, multi):
        #Scale weights by the square root of number of inputs
        self.weights = np.array([np.random.randn(size) / math.sqrt(size)])
        self.bias = 0
        self.weighth=np.array([]).reshape(0,4)
        self.missclass = 0
        self.multi = multi
        
    def update(self, x, y):
        self.a=np.dot(self.weights,x.T)+self.bias
        if (y*self.a <= 0):
            self.weighth = np.append(self.weighth,self.weights,axis=0)
            #print(self.weights)
            self.weights += y*x
            self.missclass = self.missclass+1
            self.bias+=y;
            
    def test(self, x):
        a = np.dot(self.weights, x.T)+self.bias
        #In multiclass return the value
        if (self.multi==0):           
            a[a>0]=1
            a[a<0]=-1
        return a;
        


def main():
   
    print('Please provide input about the classes:\n')
    print('1:Compare class1-class2\n')
    print('2:Compare class2-class3\n')
    print('3:Compare class1-class3\n')
    print('4:Multiclass\n')
    print('5:Visualise the data\n')
    defclass=input('Input:')
    print(defclass)
    #define classes
    if(defclass=='1'):
        single_class(1,2)
    elif(defclass=='2'):
        single_class(2,3)
    elif(defclass=='3'):
        single_class(1,3)
    elif(defclass=='4'):
        multi_class()
    elif(defclass=='5'):
        viz()
    else:
        print('Please provide a valid input 1,2 or 3')
        sys.exit()
               
def single_class(class1,class2):
    #create a conversion "function" to remove the "class-" from the last column
    #Because it is an object needs decoding to a string
    convertfunc = lambda x: float(re.sub("[^0-9]","",x.decode('utf-8')))
    
    #Import datasets as numpy arrays
    #use the convertfunc to have numbers on the last column
    train_data = np.genfromtxt('train.data',delimiter=',',converters={4: convertfunc})
    test_data = np.genfromtxt('test.data', delimiter=',', converters={4: convertfunc})
    
    #for two classes create the training inputs and the testing inputs arrays
    tr_inputs = train_data[np.where(train_data[:,4] == class1)].copy()
    tr_inputs = np.append(tr_inputs,train_data[np.where(train_data[:,4] == class2)].copy(),axis=0)
    tr_inputs[:,4]=np.where(tr_inputs[:,4]!=class1,-1,1)#change the class number into 1 and -1
    
    te_inputs = test_data[np.where(test_data[:,4] == class1)].copy()
    te_inputs = np.append(te_inputs,test_data[np.where(test_data[:,4] == class2)].copy(),axis=0)
    te_inputs[:,4] = np.where(te_inputs[:,4]!=class1,-1,1)
    size=tr_inputs.shape[1]#return the columns which is the number of dimensions
    
    
    #shuffle the order of the training data
    np.random.shuffle(tr_inputs)
    tr_features=tr_inputs[:,0:(size-1)]
    tr_class=tr_inputs[:,(size-1):size]
    #create perceptron
    #call with 0 as a parameter for binary classification
    perc1 = perceptron(size-1,0)
    for it in range(0,20):
        for it2 in range(0,tr_inputs.shape[0]):
            perc1.update(tr_features[it2:(it2+1),:],tr_class[it2:(it2+1),:])
    print('Training classification error percentage of class',class1,'and class',class2,':',perc1.missclass/(it*it2))
    #how do we measure error. Based on iterations or based on total numbers update run?
                
    #test data 
    te_features = te_inputs[:,0:(size-1)]
    te_class = te_inputs[:,(size-1):size]
    results=perc1.test(te_features[:,:]).T
    error=results==te_class
    print('Test training error',(error==False).sum()/error.size)
    
    
    

def multi_class():
    #create a conversion "function" to remove the "class-"from the last column
    #Because it is an object needs decoding to a string
    convertfunc = lambda x: float(re.sub("[^0-9]","",x.decode('utf-8')))
    #Import datasets as numpy arrays
    #use the convertfunc to have numbers on the last column
    train_data = np.genfromtxt('train.data',delimiter=',',converters={4: convertfunc})
    test_data = np.genfromtxt('test.data', delimiter=',', converters={4: convertfunc})
    #Create as many perceptrons as the classes are
    objlist=[]
    for i in range(1, 4):
        #for the current class create the training inputs and the testing inputs arrays
        tr_inputs = train_data.copy()
        tr_inputs[:,4]=np.where(tr_inputs[:,4]!=i,-1,1)
    
        te_inputs = test_data.copy()
        #In this case a change won't be made in order to evaluate the results later
        #te_inputs[:,4] = np.where(te_inputs[:,4]!=i,-1,1)
        #return the columns which is the number of dimensions
        size=tr_inputs.shape[1]
    
        #shuffle the order of the training data
        np.random.shuffle(tr_inputs)
        tr_features=tr_inputs[:,0:(size-1)]
        tr_class=tr_inputs[:,(size-1):size]
        #create perceptron
        #call with 0 as a parameter for binary classification      
        objlist.append(perceptron(size-1,1))
        for it in range(0,20):
            for it2 in range(0,tr_inputs.shape[0]):
                objlist[i-1].update(tr_features[it2:(it2+1),:],tr_class[it2:(it2+1),:])
        print('Training classification error percentage of class',i,':',objlist[i-1].missclass/(it*it2))
    
    
    #test data 
    te_features = te_inputs[:,0:(size-1)]
    te_class = te_inputs[:,(size-1):size]
    results = np.empty((0,1))
    res1=objlist[0].test(te_features[:,:]).T
    res2=objlist[1].test(te_features[:,:]).T
    res3=objlist[2].test(te_features[:,:]).T
    for y in range(0,res1.shape[0]):
        maxv=max(res1[y],res2[y],res3[y])
        if(maxv==res1[y]):
           results = np.append(results,1)
        elif(maxv==res2[y]):
            results =  np.append(results,2)
        elif(maxv==res3[y]):
            results =  np.append(results,3)
    error=results==te_class
    print('Test training error',(error==False).sum()/error.size)    
    return objlist
    
def viz():
    
    dataset = pd.read_csv('train.data',names=['first','second','third','fourth','Class'])
    classes = dataset['Class']
    #First plot
    plt.subplot(4, 3, 1)     
    plt.scatter(dataset[classes=='class-1']['first'], dataset[classes=='class-1']['second'], label='Class 1', c='red')
    plt.scatter(dataset[classes=='class-2']['first'], dataset[classes=='class-2']['second'], label='Class 2', c='blue')
    plt.scatter(dataset[classes=='class-3']['first'], dataset[classes=='class-3']['second'], label='Class 3', c='lightgreen')
    
    plt.plot
    plt.legend()
    plt.xlabel('First')
    plt.ylabel('Second')
    #Second plot
    plt.subplot(4, 3, 2)     
    plt.scatter(dataset[classes=='class-1']['first'], dataset[classes=='class-1']['third'], label='Class 1', c='red')
    plt.scatter(dataset[classes=='class-2']['first'], dataset[classes=='class-2']['third'], label='Class 2', c='blue')
    plt.scatter(dataset[classes=='class-3']['first'], dataset[classes=='class-3']['third'], label='Class 3', c='lightgreen')
    plt.legend()
    plt.xlabel('First')
    plt.ylabel('Third')
    #Third plot
    plt.subplot(4, 3, 3)     
    plt.scatter(dataset[classes=='class-1']['first'], dataset[classes=='class-1']['fourth'], label='Class 1', c='red')
    plt.scatter(dataset[classes=='class-2']['first'], dataset[classes=='class-2']['fourth'], label='Class 2', c='blue')
    plt.scatter(dataset[classes=='class-3']['first'], dataset[classes=='class-3']['fourth'], label='Class 3', c='lightgreen')
    plt.legend()
    plt.xlabel('First')
    plt.ylabel('Fourth')
    #Fourth plot
    plt.subplot(4, 3, 4)     
    plt.scatter(dataset[classes=='class-1']['second'], dataset[classes=='class-1']['third'], label='Class 1', c='red')
    plt.scatter(dataset[classes=='class-2']['second'], dataset[classes=='class-2']['third'], label='Class 2', c='blue')
    plt.scatter(dataset[classes=='class-3']['second'], dataset[classes=='class-3']['third'], label='Class 3', c='lightgreen')
    plt.legend()
    plt.xlabel('Second')
    plt.ylabel('Third')
    #Fifth plot
    plt.subplot(4, 3, 5)     
    plt.scatter(dataset[classes=='class-1']['second'], dataset[classes=='class-1']['fourth'], label='Class 1', c='red')
    plt.scatter(dataset[classes=='class-2']['second'], dataset[classes=='class-2']['fourth'], label='Class 2', c='blue')
    plt.scatter(dataset[classes=='class-3']['second'], dataset[classes=='class-3']['fourth'], label='Class 3', c='lightgreen')
    plt.legend()
    plt.xlabel('Second')
    plt.ylabel('Fourth')
    #Sixth plot
    plt.subplot(4, 3, 6)     
    plt.scatter(dataset[classes=='class-1']['third'], dataset[classes=='class-1']['fourth'], label='Class 1', c='red')
    plt.scatter(dataset[classes=='class-2']['third'], dataset[classes=='class-2']['fourth'], label='Class 2', c='blue')
    plt.scatter(dataset[classes=='class-3']['third'], dataset[classes=='class-3']['fourth'], label='Class 3', c='lightgreen')
    plt.legend()
    plt.xlabel('Third')
    plt.ylabel('Fourth')
    # display
    #PCA plot
    plt.subplot(4, 3, 7 )
    min_max=MinMaxScaler()
    normalised_data=min_max.fit_transform(dataset[['first', 'second','third', 'fourth']])
    #(dataset - dataset.min())/(dataset.max() - dataset.min())
    pca = sklearnPCA(n_components=2) #2-dimensional PCA
    reduced_data = pd.DataFrame(pca.fit_transform(normalised_data))
    plt.scatter(reduced_data[classes=='class-1'][0], reduced_data[classes=='class-1'][1], label='Class 1', c='red')
    plt.scatter(reduced_data[classes=='class-2'][0], reduced_data[classes=='class-2'][1], label='Class 2', c='blue')
    plt.scatter(reduced_data[classes=='class-3'][0], reduced_data[classes=='class-3'][1], label='Class 3', c='lightgreen')
    plt.legend()
    plt.xlabel('Reduced 1')
    plt.ylabel('Reduced 2')

    # display
    plt.show()    
    plt.tight_layout()
    
    

if __name__ == "__main__":
    main()
